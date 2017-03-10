using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class MouseHook
{
	static event MouseEventHandler s_MouseMove;
	public static event MouseEventHandler MouseMove
	{
		add
		{
			EnsureSubscribedToGlobalMouseEvents();
			s_MouseMove += value;
		}

		remove
		{
			s_MouseMove -= value;
			TryUnsubscribeFromGlobalMouseEvents();
		}
	}

	static void EnsureSubscribedToGlobalMouseEvents()
	{
		if (s_HookHandle == 0)
		{
			const int WH_MOUSE_LL = 14;

			s_HookProc = MouseHookProc;

			s_HookHandle = SetWindowsHookEx(
				 WH_MOUSE_LL, s_HookProc, IntPtr.Zero, 0);

			if (s_HookHandle == 0)
			{
				int errorCode = Marshal.GetLastWin32Error();
				throw new Win32Exception(errorCode);
			}
		}
	}

	static void TryUnsubscribeFromGlobalMouseEvents()
	{
		if (s_MouseMove == null && s_HookHandle != 0)
		{
			int result = UnhookWindowsHookEx(s_HookHandle);
			s_HookHandle = 0;
			if (result == 0)
			{
				int errorCode = Marshal.GetLastWin32Error();
				throw new Win32Exception(errorCode);
			}
		}
	}

	delegate int HookProc(int nCode, int wParam, MouseLLHookStruct lParam);
	static int s_HookHandle;
	static HookProc s_HookProc;

	static int MouseHookProc(int nCode, int wParam, MouseLLHookStruct lParam)
	{
		if (nCode >= 0 && s_MouseMove != null)
		{
			s_MouseMove.Invoke(null,
				new MouseEventArgs(MouseButtons.None, 0, lParam.X, lParam.Y, 0));
		}
		return CallNextHookEx(s_HookHandle, nCode, wParam, lParam);
	}

	[StructLayout(LayoutKind.Sequential)]
	struct MouseLLHookStruct
	{
		public int X;
		public int Y;
		public int MouseData;
		public int Flags;
		public int Time;
		public int ExtraInfo;
	}

	[DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
	static extern int CallNextHookEx(int hHook, int nCode, int wParam, MouseLLHookStruct lParam);
	[DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	static extern int SetWindowsHookEx(int hHook, HookProc lpfn, IntPtr hMod, int dwThreadId);
	[DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	static extern int UnhookWindowsHookEx(int hHook);
}
