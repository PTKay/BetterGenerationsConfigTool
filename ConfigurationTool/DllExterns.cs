using System;
using System.Runtime.InteropServices;

public class DllExterns
{
	[DllImport("DXInputHandler.dll")]
	public static extern bool _InitialiseDirectXInput(IntPtr hInstance, IntPtr hWnd);

	[DllImport("DXInputHandler.dll")]
	public static extern bool _PollKeyboard();

	[DllImport("DXInputHandler.dll")]
	public static extern int _GetKeyboardPressed();

	[DllImport("DXInputHandler.dll")]
	public static extern uint _GetKeyboardPressedAscii();

	[DllImport("DXInputHandler.dll")]
	public static extern int _GetPadListCount();

	[DllImport("DXInputHandler.dll")]
	public static extern bool _PollPad();

	[DllImport("DXInputHandler.dll")]
	public static extern IntPtr _GetPadName(int PadIndex);

	public static string GetPadName(int PadIndex)
	{
		return Marshal.PtrToStringUni(DllExterns._GetPadName(PadIndex));
	}

	[DllImport("DXInputHandler.dll")]
	public static extern void _FoundXInput(ref bool result);

	[DllImport("DXInputHandler.dll", CharSet = CharSet.Unicode)]
	public static extern bool _GetPadInfo([MarshalAs(UnmanagedType.LPStruct)] [Out] PadInfo lplf, int PadIndex);

	[DllImport("DXInputHandler.dll", CharSet = CharSet.Unicode)]
	public static extern void _GetPadPressInfo([MarshalAs(UnmanagedType.LPStruct)] [Out] sPressInfo lplf, int PadIndex);

	[DllImport("DXInputHandler.dll", CharSet = CharSet.Unicode)]
	public static extern void _GetPadPressInfoText([MarshalAs(UnmanagedType.LPStruct)] [Out] sPressInfo lplf, int PadIndex);

	[DllImport("DXInputHandler.dll")]
	public static extern void _ResetPadLists();

	[DllImport("DXInputHandler.dll")]
	public static extern uint _ConvertToAscii(int InValue);

	[DllImport("DXInputHandler.dll")]
	public static extern bool _InitialiseDirectX();

	[DllImport("DXInputHandler.dll")]
	public static extern int _GetNumberOfAdapters();

	[DllImport("DXInputHandler.dll")]
	public static extern void _GetAdapterData(int Index, ref AdapterInfo AI);

	[DllImport("DXInputHandler.dll")]
	public static extern bool _InitialiseDirectSound();

	[DllImport("DXInputHandler.dll")]
	public static extern int _GetNumberOfAudios();

	[DllImport("DXInputHandler.dll")]
	public static extern bool _GetAudioData(int Index, ref AudioInfo AI);

	[DllImport("DXInputHandler.dll")]
	public static extern int _PopulateDeviceList();
}
