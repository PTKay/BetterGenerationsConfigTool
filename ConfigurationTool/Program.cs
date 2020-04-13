using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Generations_Launcher_Front
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				FixReg(args[0]);
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		static void FixReg(string mode)
		{
			RegistryKey registryKey = null;
			Boolean fixAll = false;
			switch (mode)
			{
				case "-1":
					registryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Sega\\Sonic Generations");
					fixAll = true;
					goto case "1";
				case "1":
					if (registryKey == null) registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations", true);
					registryKey.SetValue("locale", "1033");
					if (fixAll) goto case "2";
					break;
				case "2":
					if (registryKey == null) registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations", true);
					registryKey.SetValue("SaveLocation", "My Games\\Sonic Generations\\Saved Games");
					break;
			}
			if (registryKey != null) registryKey.Close();
		}
	}
}
