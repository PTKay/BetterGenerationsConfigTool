using System;

public struct Resolution
{
	public override string ToString()
	{
		return string.Concat(this.Width.ToString(), ".", this.Height.ToString(), ".", this.Refresh.ToString());
	}

	public string DisplayName => $"{Width} x {Height} ({Refresh} hz)";
	
	public int Width;

	public int Height;

	public int Refresh;
}
