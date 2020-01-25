using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

public class RegistryData
{
	[DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
	public static extern bool SHGetSpecialFolderPathW(IntPtr owner, StringBuilder path, int folder, bool create);

	public RegistryData()
	{
		this.LCID = 1033;
		this.ReadSaveLocationFromRegistry = "";
		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations");
		if (registryKey != null)
		{
			object value = registryKey.GetValue("locale");
			if (value != null)
			{
				string a = value.ToString();
				if (a == "1033" || a == "1040" || a == "1036" || a == "1031" || a == "3082")
				{
					this.LCID = int.Parse(value.ToString());
				}
				else
				{
					this.LCID = 1033;
				}
			}
			StringBuilder stringBuilder = new StringBuilder(260);
			object value2 = registryKey.GetValue("SaveLocation");
			if (value2 == null) return;
			RegistryData.SHGetSpecialFolderPathW(IntPtr.Zero, stringBuilder, 5, false);
			stringBuilder.Insert(stringBuilder.Length, "\\");
			stringBuilder.Insert(stringBuilder.Length, value2.ToString());
			this.ReadSaveLocationFromRegistry = stringBuilder.ToString();
		}
	}

	public int LCID { get; }

	public string ReadSaveLocationFromRegistry { get; }
}
