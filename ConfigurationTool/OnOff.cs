using System;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public struct OnOff
	{
		public string DisplayName => this.bIsOn ? LocalizedText.On_combo : LocalizedText.Off_combo;

		public bool bIsOn;
	}
}
