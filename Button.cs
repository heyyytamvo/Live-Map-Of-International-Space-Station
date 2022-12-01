using System;
using SplashKitSDK;
namespace ISShd
{
	public abstract class Button : Application_Object
	{
		public double topX;
		public double topY;
		public double height;
		public double width;
		public Button(double _topX, double _topY, double _height, double _width) : base("button", false, new string[] {"button"})
		{
			topX = _topX;
			topY = _topY;
			height = _height;
			width = _width;
		}

		public bool CheckDimension(Point2D point)
        {
			if ((point.X > topX && point.X < (topX + this.width)) && (point.Y < (topY + this.height) && point.Y > topY))
            {
				return true;
            }
			return false;
        }

		public abstract void DrawButton(Bitmap bitmap);

        public override string Location()
        {
			return "This is a button";
        }
    }
}

