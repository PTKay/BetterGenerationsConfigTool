using System;
using Microsoft.Win32;

namespace FixGensRegistry
{
	class Program
	{
		static void Main(string[] args)
		{
			String mode = args.Length == 0 ? "-1" : args[0];
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
					if (registryKey == null) registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Sega\\Sonic Generations");
					registryKey.SetValue("SaveLocation", "My Games\\Sonic Generations\\Saved Games");
					break;
			}
		}
	}
}
