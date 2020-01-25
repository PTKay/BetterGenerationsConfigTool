using System;
using System.Collections.Generic;

public class GlobalDefs
{
	public GlobalDefs()
	{
		GlobalDefs.GraphicsConfigFileRead = false;
		this.KEYBOARD_GUID = new Guid("00000001-0000-0000-0000-000000000000");
		this.ZERO_GUID = new Guid("00000000-0000-0000-0000-000000000000");
	}

	public static int CacheSize
	{
		get
		{
			return GlobalDefs.m_CacheSize;
		}
		set
		{
			GlobalDefs.m_CacheSize = value;
		}
	}

	public static int CacheBlockSize
	{
		get
		{
			return GlobalDefs.m_CacheBlockSize;
		}
		set
		{
			GlobalDefs.m_CacheBlockSize = value;
		}
	}

	public static int StreamingRate
	{
		get
		{
			return GlobalDefs.m_StreamingRate;
		}
		set
		{
			GlobalDefs.m_StreamingRate = value;
		}
	}

	public static int CacheEnabled
	{
		get
		{
			return GlobalDefs.m_CachingEnabled;
		}
		set
		{
			GlobalDefs.m_CachingEnabled = value;
		}
	}

	public static List<OutputConfig> OutputConfigList = new List<OutputConfig>();

	public Guid KEYBOARD_GUID;

	public Guid ZERO_GUID;

	public static bool GraphicsConfigFileRead;

	public static bool AnalyticsEnabled = true;

	public static OutputAdapterInfo OutputAdapter = default(OutputAdapterInfo);

	public static AudioInfo OutputAudio = default(AudioInfo);

	public static bool bFirstRun = true;

	private static int m_CacheSize;

	private static int m_CacheBlockSize;

	private static int m_StreamingRate;

	private static int m_CachingEnabled;
}
