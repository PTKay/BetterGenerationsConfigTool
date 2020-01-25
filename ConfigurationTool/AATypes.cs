using System;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public struct AATypes
	{
		public string DisplayName => this.AA == 0 ? LocalizedText.Off_combo : LocalizedText.On_combo;

		public int AA;
	}
}
