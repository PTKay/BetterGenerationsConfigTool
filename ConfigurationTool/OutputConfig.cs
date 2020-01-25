using System;
using System.Collections.Generic;

public class OutputConfig
{
	public OutputConfig()
	{
		this.mProductGuid = default(Guid);
		this.mProductName = "";
		this.mAxisMap = new int[4];
		this.mButtonMap = new int[18];
		this.mMovementType = 0;
	}

	public static List<OutputConfig> mConfigList = new List<OutputConfig>();

	public Guid mProductGuid;

	public string mProductName;

	public readonly int[] mAxisMap;

	public readonly int[] mButtonMap;

	public int mDeadZone;

	public byte mMovementType;
}
