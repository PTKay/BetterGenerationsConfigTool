using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AdapterInfo
{
	public string DisplayName => this.DisplayNo == -1 ? this.AdapterDescription : string.Concat(this.AdapterDescription, " (Display ", this.DisplayNo + 1, ")");

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] AAList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public readonly string AdapterName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public readonly string AdapterDescription;

	public Guid DeviceGUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public readonly string AdapterID;

	private readonly int DisplayNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public Resolution[] AResArray;

	public readonly int NoOfRes;

	private readonly int NoOfAA;

	public readonly uint DepthFormat;

	private readonly int MaxTexHeight;

	private readonly int MaxTexWidth;

	public readonly int DefaultResIndex;
}
