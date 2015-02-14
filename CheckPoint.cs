
using System.Globalization;
namespace PathTracking
{
    class CheckPoint
    {
        public Point Coordinates { set; get; }
        public string DrawCheckPoint()
        {
            var checkPointDrawing = string.Format(CultureInfo.InvariantCulture, "M {0},{1} L {2},{3} ", Coordinates.X - 2, Coordinates.Y-2, Coordinates.X + 2, Coordinates.Y-2);
            checkPointDrawing += string.Format(CultureInfo.InvariantCulture, "L {0},{1} L {2},{3} Z", Coordinates.X + 2, Coordinates.Y+2, Coordinates.X - 2, Coordinates.Y+2);
            return checkPointDrawing;
        }

        public CheckPoint(double x, double y)
        {
            Coordinates.X = x;
            Coordinates.Y = y;
        }


    }
}
