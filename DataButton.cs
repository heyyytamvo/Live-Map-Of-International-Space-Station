using System;
using SplashKitSDK;
namespace ISShd
{
	public class DataButton : Button
	{
		public DataButton(double _topX, double _topY, double _height, double _width) : base(_topX, _topY, _height, _width)
		{
		}

		public override void DrawButton(Bitmap bitmap)
		{
			SplashKit.FillRectangleOnBitmap(bitmap, Color.Green, topX, topY, width, height);
		}
	}
}

