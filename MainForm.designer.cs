namespace ScreenColorSampler
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbColor = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.pictureBoxZoom = new System.Windows.Forms.PictureBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvColors = new System.Windows.Forms.DataGridView();
			this.colHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.cbAlwaysOnTop = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbFormat = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbAutoCopy = new System.Windows.Forms.ComboBox();
			this.cbZoom = new System.Windows.Forms.ComboBox();
			this.cbSample = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbCtrl = new System.Windows.Forms.ComboBox();
			this.splitContainer0 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColors)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.splitContainer0.Panel1.SuspendLayout();
			this.splitContainer0.Panel2.SuspendLayout();
			this.splitContainer0.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbColor
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tbColor, 2);
			this.tbColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbColor.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbColor.Location = new System.Drawing.Point(0, 0);
			this.tbColor.Margin = new System.Windows.Forms.Padding(0);
			this.tbColor.Name = "tbColor";
			this.tbColor.ReadOnly = true;
			this.tbColor.Size = new System.Drawing.Size(324, 35);
			this.tbColor.TabIndex = 0;
			// 
			// pictureBox
			// 
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(322, 461);
			this.pictureBox.TabIndex = 4;
			this.pictureBox.TabStop = false;
			this.pictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			// 
			// pictureBoxZoom
			// 
			this.pictureBoxZoom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxZoom.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxZoom.Name = "pictureBoxZoom";
			this.pictureBoxZoom.Size = new System.Drawing.Size(330, 461);
			this.pictureBoxZoom.TabIndex = 5;
			this.pictureBoxZoom.TabStop = false;
			this.pictureBoxZoom.SizeChanged += new System.EventHandler(this.pictureBoxZoom_SizeChanged);
			this.pictureBoxZoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBoxZoom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxZoom_MouseMove);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxZoom);
			this.splitContainer1.Size = new System.Drawing.Size(656, 461);
			this.splitContainer1.SplitterDistance = 322;
			this.splitContainer1.TabIndex = 0;
			// 
			// dgvColors
			// 
			this.dgvColors.AllowUserToAddRows = false;
			this.dgvColors.AllowUserToResizeRows = false;
			this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvColors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHex,
            this.colColor});
			this.tableLayoutPanel1.SetColumnSpan(this.dgvColors, 2);
			this.dgvColors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvColors.Location = new System.Drawing.Point(0, 161);
			this.dgvColors.Margin = new System.Windows.Forms.Padding(0);
			this.dgvColors.Name = "dgvColors";
			this.dgvColors.ReadOnly = true;
			this.dgvColors.RowHeadersVisible = false;
			this.dgvColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvColors.Size = new System.Drawing.Size(324, 300);
			this.dgvColors.TabIndex = 13;
			this.dgvColors.VirtualMode = true;
			this.dgvColors.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvColors_CellPainting);
			this.dgvColors.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvColors_CellValueNeeded);
			this.dgvColors.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvColors_RowsRemoved);
			// 
			// colHex
			// 
			this.colHex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colHex.HeaderText = "Value";
			this.colHex.Name = "colHex";
			this.colHex.ReadOnly = true;
			this.colHex.Width = 59;
			// 
			// colColor
			// 
			this.colColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colColor.HeaderText = "Color";
			this.colColor.Name = "colColor";
			this.colColor.ReadOnly = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel1.Controls.Add(this.cbAlwaysOnTop, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cbFormat, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.cbAutoCopy, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.cbZoom, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.cbSample, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbColor, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvColors, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.cbCtrl, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 461);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// cbAlwaysOnTop
			// 
			this.cbAlwaysOnTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbAlwaysOnTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAlwaysOnTop.FormattingEnabled = true;
			this.cbAlwaysOnTop.Items.AddRange(new object[] {
            "No",
            "Yes"});
			this.cbAlwaysOnTop.Location = new System.Drawing.Point(129, 56);
			this.cbAlwaysOnTop.Margin = new System.Windows.Forms.Padding(0);
			this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
			this.cbAlwaysOnTop.Size = new System.Drawing.Size(195, 21);
			this.cbAlwaysOnTop.TabIndex = 4;
			this.cbAlwaysOnTop.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(47, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Always On Top";
			// 
			// cbFormat
			// 
			this.cbFormat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFormat.FormattingEnabled = true;
			this.cbFormat.Items.AddRange(new object[] {
            "Integer",
            "Hex"});
			this.cbFormat.Location = new System.Drawing.Point(129, 140);
			this.cbFormat.Margin = new System.Windows.Forms.Padding(0);
			this.cbFormat.Name = "cbFormat";
			this.cbFormat.Size = new System.Drawing.Size(195, 21);
			this.cbFormat.TabIndex = 12;
			this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(87, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Format";
			// 
			// cbAutoCopy
			// 
			this.cbAutoCopy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbAutoCopy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAutoCopy.FormattingEnabled = true;
			this.cbAutoCopy.Items.AddRange(new object[] {
            "No",
            "Yes"});
			this.cbAutoCopy.Location = new System.Drawing.Point(129, 119);
			this.cbAutoCopy.Margin = new System.Windows.Forms.Padding(0);
			this.cbAutoCopy.Name = "cbAutoCopy";
			this.cbAutoCopy.Size = new System.Drawing.Size(195, 21);
			this.cbAutoCopy.TabIndex = 10;
			this.cbAutoCopy.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// cbZoom
			// 
			this.cbZoom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbZoom.FormattingEnabled = true;
			this.cbZoom.Items.AddRange(new object[] {
            "2x",
            "4x",
            "8x",
            "16x",
            "32x"});
			this.cbZoom.Location = new System.Drawing.Point(129, 98);
			this.cbZoom.Margin = new System.Windows.Forms.Padding(0);
			this.cbZoom.Name = "cbZoom";
			this.cbZoom.Size = new System.Drawing.Size(195, 21);
			this.cbZoom.TabIndex = 8;
			this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// cbSample
			// 
			this.cbSample.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSample.FormattingEnabled = true;
			this.cbSample.Items.AddRange(new object[] {
            "1x1",
            "3x3",
            "5x5",
            "7x7"});
			this.cbSample.Location = new System.Drawing.Point(129, 77);
			this.cbSample.Margin = new System.Windows.Forms.Padding(0);
			this.cbSample.Name = "cbSample";
			this.cbSample.Size = new System.Drawing.Size(195, 21);
			this.cbSample.TabIndex = 6;
			this.cbSample.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mode";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(92, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Zoom";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(61, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Sample Size";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(70, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Auto Copy";
			// 
			// cbCtrl
			// 
			this.cbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCtrl.FormattingEnabled = true;
			this.cbCtrl.Items.AddRange(new object[] {
            "Continuous",
            "CTRL Key"});
			this.cbCtrl.Location = new System.Drawing.Point(129, 35);
			this.cbCtrl.Margin = new System.Windows.Forms.Padding(0);
			this.cbCtrl.Name = "cbCtrl";
			this.cbCtrl.Size = new System.Drawing.Size(195, 21);
			this.cbCtrl.TabIndex = 2;
			this.cbCtrl.SelectedIndexChanged += new System.EventHandler(this.comboBoxChanged);
			// 
			// splitContainer0
			// 
			this.splitContainer0.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer0.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer0.Location = new System.Drawing.Point(0, 0);
			this.splitContainer0.Name = "splitContainer0";
			// 
			// splitContainer0.Panel1
			// 
			this.splitContainer0.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer0.Panel2
			// 
			this.splitContainer0.Panel2.Controls.Add(this.splitContainer1);
			this.splitContainer0.Size = new System.Drawing.Size(984, 461);
			this.splitContainer0.SplitterDistance = 324;
			this.splitContainer0.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 461);
			this.Controls.Add(this.splitContainer0);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Color Sampler";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvColors)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer0.Panel1.ResumeLayout(false);
			this.splitContainer0.Panel2.ResumeLayout(false);
			this.splitContainer0.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbColor;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.PictureBox pictureBoxZoom;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvColors;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer0;
		private System.Windows.Forms.ComboBox cbAutoCopy;
		private System.Windows.Forms.ComboBox cbZoom;
		private System.Windows.Forms.ComboBox cbSample;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCtrl;
		private System.Windows.Forms.ComboBox cbFormat;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHex;
		private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
		private System.Windows.Forms.ComboBox cbAlwaysOnTop;
		private System.Windows.Forms.Label label6;
	}
}