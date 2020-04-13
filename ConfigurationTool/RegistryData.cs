using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

public class RegistryData
{
	[DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
	public static extern bool SHGetSpecialFolderPathW(IntPtr owner, StringBuilder path, int folder, bool create);

	public RegistryData()
	{
		int fixRegistry = 0;
		this.LCID = 1033;
		this.ReadSaveLocationFromRegistry = "";
		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations");
		if (registryKey == null)
		{
			FixRegistry(-1);
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations");
		}
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
		else
		{
			++fixRegistry;
			this.LCID = 1033;
		}
		StringBuilder stringBuilder = new StringBuilder(260);
		object value2 = registryKey.GetValue("SaveLocation");
		if (value2 == null)
		{
			++fixRegistry;
			value2 = "My Games\\Sonic Generations\\Saved Games";
		}
		RegistryData.SHGetSpecialFolderPathW(IntPtr.Zero, stringBuilder, 5, false);
		stringBuilder.Insert(stringBuilder.Length, "\\");
		stringBuilder.Insert(stringBuilder.Length, value2.ToString());
		this.ReadSaveLocationFromRegistry = stringBuilder.ToString();
		FixRegistry(fixRegistry);
	}

	private void FixRegistry(int fixType)
	{
		if (fixType != 0)
		{
			
			var psi = new ProcessStartInfo
			{
				FileName = Assembly.GetExecutingAssembly().Location,
				Arguments = fixType.ToString(),
				Verb = "runas"
			};

			var process = new Process
			{
				StartInfo = psi
			};
			process.Start();
			process.WaitForExit();
		}
	}

	public int LCID { get; }

	public string ReadSaveLocationFromRegistry { get; }
}
