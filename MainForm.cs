using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace ScreenColorSampler
{
	public partial class MainForm : Form
	{
		Point screenOffset, previewOffset, zoomOffset;
		Color color = Color.Black;
		Bitmap bm, bmBack, bmZoom, bmZoomBack;
		Thread thread = null;
		ThreadMode threadMode = ThreadMode.Screen;
		bool updating = false;
		bool ctrl = false;
		bool append = true;
		Settings settings = null;

		public MainForm()
		{
			this.Font = SystemFonts.MessageBoxFont;
			InitializeComponent();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			updating = true;
			settings = Settings.Load();
			cbCtrl.SelectedIndex = settings.Mode == Mode.CtrlKey ? 1 : 0;
			cbAlwaysOnTop.SelectedIndex = settings.AlwaysOnTop ? 1 : 0;
			cbSample.SelectedIndex = settings.SampleSize;
			cbZoom.SelectedIndex = settings.Zoom;
			cbAutoCopy.SelectedIndex = settings.AutoCopy ? 1 : 0;
			cbFormat.SelectedIndex = settings.Format == Format.Hex ? 1 : 0;
			this.Location = settings.WindowLocation;
			this.Size = settings.WindowSize;

			thread = new Thread(new ThreadStart(grabLoop));
			thread.IsBackground = true;
			thread.Start();

			MouseHook.MouseMove += MouseHook_MouseMove;

			updating = false;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.TopMost = settings.AlwaysOnTop;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			MouseHook.MouseMove -= MouseHook_MouseMove;

			settings.AlwaysOnTop = this.TopMost;
			settings.WindowLocation = this.Location;
			settings.WindowSize = this.Size;

			getSettings();
			Settings.Save(settings);
		}

		void getSettings()
		{
			settings.Mode = cbCtrl.SelectedIndex == 0 ? Mode.Continuous : Mode.CtrlKey;
			settings.AlwaysOnTop = cbAlwaysOnTop.SelectedIndex == 1;
			settings.SampleSize = cbSample.SelectedIndex;
			settings.Zoom = cbZoom.SelectedIndex;
			settings.AutoCopy = cbAutoCopy.SelectedIndex == 1;
			settings.Format = cbFormat.SelectedIndex == 0 ? Format.Integer : Format.Hex;
		}

		void comboBoxChanged(object sender, EventArgs e)
		{
			if (updating)
				return;

			getSettings();
			this.TopMost = settings.AlwaysOnTop;
		}

		void MouseHook_MouseMove(object sender, MouseEventArgs e)
		{
			if (!this.Visible)
				return;

			if (ModifierKeys == Keys.Control)
			{
				if (ctrl == false)
				{
					append = true;
					ctrl = true;
				}
			}
			else
			{
				ctrl = false;
				if (settings.Mode != Mode.Continuous)
					return;
			}

			if (e.Location.X > this.Location.X &&
				e.Location.Y > this.Location.Y &&
				e.Location.X < this.Location.X + this.Size.Width &&
				e.Location.Y < this.Location.Y + this.Size.Height)
			{
				// inside window, don't sample
				return;
			}

			lock (thread)
			{
				threadMode = ThreadMode.Screen;
				screenOffset = e.Location;
				previewOffset = new Point(0, 0);
				zoomOffset = new Point(bmZoom.Width / 2, bmZoom.Height / 2);
				Monitor.Pulse(thread);
			}
		}

		static void capture(Bitmap bm, Point p)
		{
			using (Graphics g = Graphics.FromImage(bm))
			{
				int x = p.X - bm.Width / 2;
				int y = p.Y - bm.Height / 2;
				g.FillRectangle(Brushes.Gray, g.ClipBounds);
				g.CopyFromScreen(x, y, 0, 0, bm.Size);
			}
		}

		void process(Bitmap src, Bitmap dst)
		{
			using (Graphics g = Graphics.FromImage(dst))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.Half;
				g.FillRectangle(Brushes.Gray, g.ClipBounds);

				// rounding and truncating are somewhat convoluted
				// to get the zoomed image centered with the sample
				// area pixel perfect

				int zoom = (int)Math.Pow(2.0, settings.Zoom + 1);
				int w = (dst.Width / zoom / 2) * 2 + 1;
				int h = (dst.Height / zoom / 2) * 2 + 1;
				int x0 = (src.Width - w) / 2 + previewOffset.X;
				int y0 = (src.Height - h) / 2 + previewOffset.Y;

				g.DrawImage(src,
					new RectangleF(0, 0, dst.Width, dst.Height),
					new RectangleF(x0, y0, w, h),
					GraphicsUnit.Pixel);

				int s = settings.SampleSize;
				float wp = dst.Width / (float)w;
				float hp = dst.Height / (float)h;
				float ws = wp * (2.0f * s + 1.0f);
				float hs = hp * (2.0f * s + 1.0f);

				float xp = (zoomOffset.X - dst.Width * 0.5f) / wp;
				float yp = (zoomOffset.Y - dst.Height * 0.5f) / hp;
				int xx = (int)(xp < 0.0f ? xp - 0.5f : xp + 0.5f);
				int yy = (int)(yp < 0.0f ? yp - 0.5f : yp + 0.5f);

				g.DrawRectangle(Pens.Gray,
					xx * wp + (dst.Width - ws) * 0.5f,
					yy * hp + (dst.Height - hs) * 0.5f,
					ws, hs);

				int n = 0;
				int sr = 0, sg = 0, sb = 0;
				int xc = src.Width / 2 + previewOffset.X + xx - 1;
				int yc = src.Height / 2 + previewOffset.Y + yy - 1;

				for (int j = -s; j <= s; j++)
				{
					for (int i = -s; i <= s; i++)
					{
						int x = i + xc;
						int y = j + yc;
						if (x < 0 || y < 0 || x >= src.Width || y >= src.Height)
							continue;

						Color c = src.GetPixel(x, y);
						sr += c.R;
						sg += c.G;
						sb += c.B;
						n++;
					}
				}

				if (n > 0)
					color = Color.FromArgb(sr / n, sg / n, sb / n);
			}
		}

		string formatColor(Color color)
		{
			if (settings.Format == Format.Hex)
				return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
			else
				return color.R + ", " + color.G + ", " + color.B;
		}

		void update()
		{
			tbColor.Text = formatColor(color);

			tbColor.BackColor = color;
			tbColor.ForeColor = color.R + color.G + color.B < 300 ? Color.White : Color.Black;
			//tbColor.ForeColor = Color.FromArgb(color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);

			if (settings.AutoCopy)
				Clipboard.SetText(tbColor.Text);

			if (append)
			{
				append = false;
				int extra = settings.Colors.Count - settings.MaxColorsHistory;
				if (extra > 0)
				{
					settings.Colors.RemoveRange(settings.Colors.Count - extra, extra);
				}
				settings.Colors.Insert(0, color.ToArgb());

				dgvColors.RowCount = settings.Colors.Count;
				dgvColors.AutoResizeColumns();
				dgvColors.Refresh();
			}
			else
			{
				settings.Colors[0] = color.ToArgb();
				dgvColors.InvalidateRow(0);
			}
		}

		void grabLoop()
		{
			while (true)
			{
				if (threadMode == ThreadMode.Screen)
					capture(bmBack, screenOffset);

				process(bmBack, bmZoomBack);

				this.Invoke((MethodInvoker)delegate ()
				{
					if (threadMode == ThreadMode.Screen)
					{
						Swap(ref bm, ref bmBack);
						pictureBox.Image = bm;
					}

					Swap(ref bmZoom, ref bmZoomBack);
					pictureBoxZoom.Image = bmZoom;

					update();
				});

				lock (thread)
					Monitor.Wait(thread);
			}
		}

		void pictureBox_SizeChanged(object sender, EventArgs e)
		{
			int w = pictureBox.Width;
			int h = pictureBox.Height;
			bm = new Bitmap(w, h);
			bmBack = new Bitmap(w, h);
			pictureBox.Image = bm;
		}

		void pictureBoxZoom_SizeChanged(object sender, EventArgs e)
		{
			int w = pictureBoxZoom.Width;
			int h = pictureBoxZoom.Height;
			bmZoom = new Bitmap(w, h);
			bmZoomBack = new Bitmap(w, h);
			pictureBoxZoom.Image = bmZoom;
		}


		void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			append = true;
		}

		void pictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.None)
				return;

			lock (thread)
			{
				threadMode = ThreadMode.Preview;
				zoomOffset = new Point(bmZoom.Width / 2, bmZoom.Height / 2);
				previewOffset = new Point(e.X - bm.Width / 2, e.Y - bm.Height / 2);
				Monitor.Pulse(thread);
			}
		}

		void pictureBoxZoom_MouseMove(object sender, MouseEventArgs e)
		{
			lock (thread)
			{
				threadMode = ThreadMode.Zoom;
				zoomOffset = e.Location;
				Monitor.Pulse(thread);
			}
		}

		void dgvColors_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (settings == null || settings.Colors == null || e.RowIndex >= settings.Colors.Count)
				return;

			if (e.ColumnIndex == 0)
				e.Value = formatColor(Color.FromArgb(settings.Colors[e.RowIndex]));
		}

		void dgvColors_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (settings == null || settings.Colors == null || e.RowIndex >= settings.Colors.Count)
				return;

			if (e.RowIndex >= 0 && e.ColumnIndex == 1)
			{
				Color c = Color.FromArgb(settings.Colors[e.RowIndex]);
				using (SolidBrush b = new SolidBrush(c))
				{
					e.Graphics.FillRectangle(b,
						e.CellBounds.X, e.CellBounds.Y,
						e.CellBounds.Width - 1, e.CellBounds.Height - 1);
				}

				if (dgvColors.Rows[e.RowIndex].Selected)
				{
					e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
				}

				e.Handled = true;
			}
		}

		void dgvColors_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (settings == null || settings.Colors == null)
				return;

			settings.Colors.RemoveRange(e.RowIndex, e.RowCount);
		}

		static void Swap<T>(ref T x, ref T y)
		{
			T tmp = x;
			x = y;
			y = tmp;
		}
	}

	enum ThreadMode
	{
		Screen,
		Preview,
		Zoom,
	}
}
