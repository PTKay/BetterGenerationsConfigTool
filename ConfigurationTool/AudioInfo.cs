using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AudioInfo
{
	public string DisplayName => this.description;

	public Guid AudioGuid;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
	public string description;
}
