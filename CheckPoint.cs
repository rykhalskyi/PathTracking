
using System.Globalization;
namespace PathTracking
{
    class CheckPoint
    {
        private const string FrameString = "M 0,0 L 100,0 L 100,100 L 0,100 Z ";

        private Point _coordinates = new Point();
        public Point Coordinates 
        {
            get { return _coordinates; }
        }

        public string Content
        {
            get { return DrawCheckPoint(); }
        }

        private string DrawCheckPoint()
        {
            var checkPointDrawing = string.Format(CultureInfo.InvariantCulture, "M {0},{1} L {2},{3} ", Coordinates.X - 2, Coordinates.Y-2, Coordinates.X + 2, Coordinates.Y-2);
            checkPointDrawing += string.Format(CultureInfo.InvariantCulture, "L {0},{1} L {2},{3} Z", Coordinates.X + 2, Coordinates.Y+2, Coordinates.X - 2, Coordinates.Y+2);
            checkPointDrawing += FrameString;
            return checkPointDrawing;
        }

        public CheckPoint(double x, double y)
        {
            Coordinates.X = x;
            Coordinates.Y = y;
        }


    }
}
