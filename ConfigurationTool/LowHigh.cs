using System;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public struct LowHigh
	{
		public string DisplayName => bIsHigh ? LocalizedText.High_Combo : LocalizedText.Low_Combo;

		public bool bIsHigh;
	}
}
