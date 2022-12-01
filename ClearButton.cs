using System;
using SplashKitSDK;

namespace ISShd
{
	public class ClearButton : Button
	{
		public ClearButton(double _topX, double _topY, double _height, double _width) : base(_topX, _topY, _height, _width)
		{ 
		}

        public override void DrawButton(Bitmap bitmap)
        {
            SplashKit.FillRectangleOnBitmap(bitmap, Color.Red, topX, topY, width, height);
        }
    }
}

