using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class FileHandler
{
	private bool SavePadConfigurations()
	{
		RegistryData registryData = new RegistryData();
		string text = registryData.ReadSaveLocationFromRegistry;
		if (text == "")
		{
			return false;
		}
		if (!File.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		text += "\\PlayerInput.cfg";
		List<string> list = new List<string>();
		GlobalDefs globalDefs = new GlobalDefs();
		foreach (OutputConfig outputConfig in GlobalDefs.OutputConfigList)
		{
			if (!(outputConfig.mProductGuid == globalDefs.ZERO_GUID))
			{
				list.Add(outputConfig.mProductName.ToString());
				string text2 = "$G:";
				text2 += outputConfig.mProductGuid.ToString();
				string text3 = "";
				for (int i = 0; i < outputConfig.mButtonMap.Length; i++)
				{
					text3 += outputConfig.mButtonMap[i].ToString();
					text3 += " ";
				}
				text3 += outputConfig.mMovementType;
				text2 += "$B:";
				text2 += text3;
				string text4 = "";
				for (int j = 0; j < outputConfig.mAxisMap.Length; j++)
				{
					text4 += outputConfig.mAxisMap[j].ToString();
					text4 += " ";
				}
				text2 += "$A:";
				text2 += text4;
				text2 += "$D:";
				text2 += outputConfig.mDeadZone.ToString();
				text2 += "$";
				list.Add(text2);
			}
		}
		File.WriteAllLines(text, list.ToArray());
		return true;
	}

	private bool SaveGraphicsConfiguration()
	{
		string path = "GraphicsConfig.cfg";
		List<string> list = new List<string>();
		if (GlobalDefs.OutputAdapter.ValidAdapter)
		{
			list.Add("Do not manually edit this file, use the configuration tool.");
			list.Add(GlobalDefs.OutputAdapter.AdapterDescription);
			list.Add(GlobalDefs.OutputAdapter.AdapterName);
			list.Add(GlobalDefs.OutputAdapter.OutputRes.ToString());
			list.Add(GlobalDefs.OutputAdapter.AA.ToString());
			list.Add((GlobalDefs.OutputAdapter.bVSync ? 1 : 0).ToString());
			list.Add((GlobalDefs.OutputAdapter.ShadQuality ? 1 : 0).ToString());
			list.Add((GlobalDefs.OutputAdapter.ReflectQuality ? 1 : 0).ToString());
			list.Add((GlobalDefs.OutputAdapter.DisplayMode ? 1 : 0).ToString());
			list.Add("");
			list.Add("");
			list.Add(GlobalDefs.OutputAdapter.DepthFormat.ToString());
		}
		else
		{
			list.Add("No Valid Graphics Adapter");
		}
		File.WriteAllLines(path, list.ToArray());
		return true;
	}

	public bool SaveAudioConfiguration()
	{
		string path = "AudioConfig.cfg";
		File.WriteAllLines(path, new List<string>
		{
			GlobalDefs.OutputAudio.description,
			GlobalDefs.OutputAudio.AudioGuid.ToString()
		}.ToArray());
		return true;
	}

	public bool SaveAdvancedConfiguration()
	{
		string path = "AdvancedConfig.cfg";
		File.WriteAllLines(path, new List<string>
		{
			GlobalDefs.CacheEnabled.ToString(),
			GlobalDefs.CacheSize.ToString(),
			GlobalDefs.CacheBlockSize.ToString(),
			GlobalDefs.StreamingRate.ToString()
		}.ToArray());
		return true;
	}

	private bool SaveStatsConfiguration()
	{
		string path = "StatsConfig.cfg";
		string contents = (GlobalDefs.AnalyticsEnabled ? 1 : 0).ToString();
		File.WriteAllText(path, contents);
		return true;
	}

	public bool SaveFile()
	{
		this.SavePadConfigurations();
		this.SaveGraphicsConfiguration();
		this.SaveAudioConfiguration();
		this.SaveStatsConfiguration();
		this.SaveAdvancedConfiguration();
		return true;
	}

	public bool LoadPadConfigurations()
	{
		RegistryData registryData = new RegistryData();
		const string text = "DefaultInput.cfg";
		string text2 = registryData.ReadSaveLocationFromRegistry + "\\PlayerInput.cfg";
		try
		{
			if (File.Exists(text))
			{
				this.LoadInfoConfig(text, -1);
			}
			if (File.Exists(text2))
			{
				this.LoadInfoConfig(text2, -1);
			}
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public bool LoadGraphicsConfiguration()
	{
		if (!File.Exists("GraphicsConfig.cfg"))
		{
			return false;
		}
		string[] array = File.ReadAllLines("GraphicsConfig.cfg");
		if (array.Length != 12)
		{
			return false;
		}
		GlobalDefs.OutputAdapter.AdapterDescription = array[1];
		GlobalDefs.OutputAdapter.AdapterName = array[2];
		string[] array2 = array[3].Split('.');
		Regex regex = new Regex("[^0-9]");
		GlobalDefs.OutputAdapter.OutputRes.Width = Convert.ToInt32(regex.Replace(array2[0], string.Empty));
		GlobalDefs.OutputAdapter.OutputRes.Height = Convert.ToInt32(regex.Replace(array2[1], string.Empty));
		GlobalDefs.OutputAdapter.OutputRes.Refresh = Convert.ToInt32(regex.Replace(array2[2], string.Empty));
		GlobalDefs.OutputAdapter.AA = Convert.ToInt32(regex.Replace(array[4], string.Empty));
		Regex regex2 = new Regex("[^0-1]");
		GlobalDefs.OutputAdapter.bVSync = (regex2.Replace(array[5], string.Empty) == "1");
		GlobalDefs.OutputAdapter.ShadQuality = (regex2.Replace(array[6], string.Empty) == "1");
		GlobalDefs.OutputAdapter.ReflectQuality = (regex2.Replace(array[7], string.Empty) == "1");
		GlobalDefs.OutputAdapter.DisplayMode = (regex2.Replace(array[8], string.Empty) == "1");
		GlobalDefs.OutputAdapter.DepthFormat = Convert.ToUInt32(regex.Replace(array[11], string.Empty));
		GlobalDefs.OutputAdapter.ValidAdapter = true;
		return true;
	}

	public bool LoadAdvancedConfiguration()
	{
		if (!File.Exists("AdvancedConfig.cfg"))
		{
			return false;
		}
		string[] array = File.ReadAllLines("AdvancedConfig.cfg");
		if (array.Length != 4)
		{
			return false;
		}
		GlobalDefs.CacheEnabled = int.Parse(array[0]);
		GlobalDefs.CacheSize = int.Parse(array[1]);
		GlobalDefs.CacheBlockSize = int.Parse(array[2]);
		GlobalDefs.StreamingRate = int.Parse(array[3]);
		return true;
	}

	public bool LoadAudioConfiguration()
	{
		if (!File.Exists("AudioConfig.cfg"))
		{
			return false;
		}
		string[] array = File.ReadAllLines("AudioConfig.cfg");
		if (array.Length != 2)
		{
			return false;
		}
		GlobalDefs.OutputAudio.description = array[0];
		string text = array[1];
		string[] array2 = text.Split('-');
		if (array2.Length != 5 || array2[0].Length != 8 || array2[1].Length != 4 || array2[2].Length != 4 || array2[3].Length != 4 || array2[4].Length != 12)
		{
			return false;
		}
		GlobalDefs.OutputAudio.AudioGuid = new Guid(text);
		return true;
	}

	public bool LoadGraphicsFile()
	{
		GlobalDefs.GraphicsConfigFileRead = this.LoadGraphicsConfiguration();
		return true;
	}

	public bool LoadStatsConfiguration()
	{
		if (!File.Exists("StatsConfig.cfg"))
		{
			return false;
		}
		string[] array = File.ReadAllLines("StatsConfig.cfg");
		if (array.Length != 1)
		{
			return false;
		}
		GlobalDefs.AnalyticsEnabled = (Convert.ToInt32(array[0]) == 1);
		return true;
	}

	public bool LoadFile()
	{
		GlobalDefs.bFirstRun = !this.LoadStatsConfiguration();
		return this.LoadPadConfigurations();
	}

	public bool LoadInfoConfig(string ConfigFileName, int PadIndex)
	{
		string[] array = File.ReadAllLines(ConfigFileName);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string[] array2 = array[i].Split(new char[]
			{
				'$'
			});
			for (int j = 0; j < array2.Length; j++)
			{
				if (array2[j].StartsWith("G:"))
				{
					string input = array2[j].Remove(0, 2);
					Regex regex = new Regex("[^0-9, ,\\-,^a-z,^A-Z]");
					text2 += regex.Replace(input, string.Empty);
				}
				else if (array2[j].StartsWith("B:"))
				{
					Regex regex2 = new Regex("[^0-9, ]");
					text3 += regex2.Replace(array2[j], string.Empty);
				}
				else if (array2[j].StartsWith("A:"))
				{
					Regex regex3 = new Regex("[^0-9, ]");
					text4 += regex3.Replace(array2[j], string.Empty);
				}
				else if (array2[j].StartsWith("D:"))
				{
					Regex regex4 = new Regex("[^0-9, ]");
					text5 += regex4.Replace(array2[j], string.Empty);
				}
				else
				{
					text += array2[j];
				}
			}
			text = text.TrimStart(new char[]
			{
				' '
			});
			text = text.TrimEnd(new char[]
			{
				' '
			});
			text2 = text2.TrimStart(new char[]
			{
				' '
			});
			text2 = text2.TrimEnd(new char[]
			{
				' '
			});
			if (text != "")
			{
				list.Add(text);
			}
			if (text2 != "")
			{
				list2.Add(text2);
			}
			if (text3 != "")
			{
				list3.Add(text3);
			}
			if (text4 != "")
			{
				list4.Add(text4);
			}
			if (text5 != "")
			{
				list5.Add(text5);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			string[] array3 = list2[k].Split(new char[]
			{
				'-'
			});
			if (array3.Length != 5 || array3[0].Length != 8 || array3[1].Length != 4 || array3[2].Length != 4 || array3[3].Length != 4 || array3[4].Length != 12)
			{
				list2.Remove(list2[k]);
				list.Remove(list[k]);
				list3.Remove(list3[k]);
				list4.Remove(list4[k]);
				list5.Remove(list5[k]);
			}
		}
		int num = 0;
		int[] array4 = new int[18];
		int[] array5 = array4;
		int[] array6 = new int[4];
		int[] array7 = array6;
		int mDeadZone = 0;
		byte mMovementType = 0;
		foreach (string text6 in list2)
		{
			string[] array8 = list3[num].Split(new char[]
			{
				' '
			});
			int l;
			for (l = 0; l < array8.Length; l++)
			{
				if (l >= 18)
				{
					break;
				}
				if (array8[l] != "")
				{
					array5[l] = Convert.ToInt32(array8[l]);
				}
				else
				{
					array5[l] = 0;
				}
			}
			while (l < 18)
			{
				array5[l] = 0;
				l++;
			}
			int num2 = array8.Length - 1;
			while (array8[num2] == "" && num2 >= 0)
			{
				num2--;
			}
			mMovementType = Convert.ToByte(array8[num2]);
			string[] array9 = list4[num].Split(new char[]
			{
				' '
			});
			for (l = 0; l < array9.Length; l++)
			{
				if (l >= 4)
				{
					break;
				}
				if (array9[l] != "")
				{
					array7[l] = Convert.ToInt32(array9[l]);
				}
				else
				{
					array7[l] = 0;
				}
			}
			while (l < 4)
			{
				array7[l] = 0;
				l++;
			}
			if (list5[num] != "")
			{
				mDeadZone = Convert.ToInt32(list5[num]);
			}
			else
			{
				mDeadZone = 0;
			}
			bool flag = false;
			if (PadIndex < 0)
			{
				foreach (OutputConfig outputConfig in GlobalDefs.OutputConfigList)
				{
					Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
					if (text6 == guid.ToString())
					{
						flag = true;
						break;
					}
					if (text6 == outputConfig.mProductGuid.ToString())
					{
						array5.CopyTo(outputConfig.mButtonMap, 0);
						array7.CopyTo(outputConfig.mAxisMap, 0);
						outputConfig.mDeadZone = mDeadZone;
						outputConfig.mMovementType = mMovementType;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					OutputConfig outputConfig2 = new OutputConfig();
					outputConfig2.mProductGuid = new Guid(text6);
					outputConfig2.mProductName = list[num];
					array5.CopyTo(outputConfig2.mButtonMap, 0);
					array7.CopyTo(outputConfig2.mAxisMap, 0);
					outputConfig2.mDeadZone = mDeadZone;
					outputConfig2.mMovementType = mMovementType;
					GlobalDefs.OutputConfigList.Add(outputConfig2);
				}
			}
			else
			{
				if (PadIndex >= GlobalDefs.OutputConfigList.Count<OutputConfig>())
				{
					return false;
				}
				if (text6 == GlobalDefs.OutputConfigList[PadIndex].mProductGuid.ToString())
				{
					array5.CopyTo(GlobalDefs.OutputConfigList[PadIndex].mButtonMap, 0);
					array7.CopyTo(GlobalDefs.OutputConfigList[PadIndex].mAxisMap, 0);
					GlobalDefs.OutputConfigList[PadIndex].mDeadZone = mDeadZone;
					GlobalDefs.OutputConfigList[PadIndex].mMovementType = mMovementType;
					return true;
				}
			}
			num++;
		}
		return PadIndex == -1;
	}

	private bool PopulateAdapterList()
	{
		return true;
	}

	[Flags]
	private enum ReadingConfigFlags
	{
		RC_None = 0,
		RC_Name = 1,
		RC_Guid = 2,
		RC_Button = 4,
		RC_Axis = 8,
		RC_Dead = 22
	}
}
