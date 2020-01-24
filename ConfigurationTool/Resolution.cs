using System;

public struct Resolution
{
	public override string ToString()
	{
		return string.Concat(new string[]
		{
			this.Width.ToString(),
			".",
			this.Height.ToString(),
			".",
			this.Refresh.ToString()
		});
	}

	public string DisplayName => $"{Width} x {Height} ({Refresh} hz)";

	/*
			string str = "";
			if (this.Width >= 1000)
			{
				str = str + this.Width.ToString() + "   x  ";
			}
			else
			{
				str = str + "  " + this.Width.ToString() + "   x  ";
			}
			if (this.Height >= 1000)
			{
				str = str + this.Height.ToString() + "  :  ";
			}
			else
			{
				str = str + " " + this.Height.ToString() + "   :  ";
			}
			return str + this.Refresh.ToString();
			*/
	public int Width;

	public int Height;

	public int Refresh;
}
