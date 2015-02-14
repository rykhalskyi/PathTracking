
using System;
using System.Collections.Generic;
using System.Globalization;
namespace PathTracking
{
    public class SimpleShipDrawer: BaseAirCraft
    {
        public SimpleShipDrawer():base()
        {
        }
        
        protected override void FillPoints()
        {
            Points.Add(new Point() { X = -1, Y = 0 });
            Points.Add(new Point() { X = 1, Y = 0 });
            Points.Add(new Point() { X = 0, Y = -3 });
            Points.Add(new Point() { X = 0, Y = 3 });
            Points.Add(new Point() { X = -1, Y = -2 });
            Points.Add(new Point() { X = 1, Y = -2 });

            for (int i=0; i<Points.Count; i++)
            {
                CalculatedPoints.Add(new Point() { X = 0, Y = 0 });
            }
        }

        public override string DrawShip()
        {
            var shipDrawing = string.Format(CultureInfo.InvariantCulture, "M {0},{1} L {2},{3} ", CalculatedPoints[0].X, CalculatedPoints[0].Y, CalculatedPoints[1].X, CalculatedPoints[1].Y);
            shipDrawing += string.Format(CultureInfo.InvariantCulture, "M {0},{1} L {2},{3} ", CalculatedPoints[2].X, CalculatedPoints[2].Y, CalculatedPoints[3].X, CalculatedPoints[3].Y);
            shipDrawing += string.Format(CultureInfo.InvariantCulture, "M {0},{1} L {2},{3} ", CalculatedPoints[4].X, CalculatedPoints[4].Y, CalculatedPoints[2].X, CalculatedPoints[2].Y);
            shipDrawing += string.Format(CultureInfo.InvariantCulture, "L {0},{1}", CalculatedPoints[5].X, CalculatedPoints[5].Y);
            return shipDrawing;
        }

    }

    public class BaseAirCraft: IAirCraft
    {
        protected virtual void FillPoints()
        {
        }

        public BaseAirCraft()
        {
            Points = new List<Point>();
            CalculatedPoints = new List<Point>();
            Coordinates = new Point();
            Angle = 0;
            FillPoints();
        }
        
        public virtual string DrawShip()
        {
            return string.Empty;
        }

        protected System.Collections.Generic.List<Point> Points { get; set; }
        protected List<Point> CalculatedPoints { get; set; }
        protected double Angle { get; set; }

        public Point Coordinates { get; protected set; }

        public void Rotate(double angle)
        {
            Angle += angle;
            angle = Angle * Math.PI / 180;
            for (int i = 0; i < Points.Count; i++)
            {
                CalculatedPoints[i].X = Points[i].X * Math.Cos(angle) - Points[i].Y * Math.Sin(angle);
                CalculatedPoints[i].Y = Points[i].X * Math.Sin(angle) + Points[i].Y * Math.Cos(angle);
            }
        }

        public void Translate(double x, double y)
        {
            Coordinates.X += x;
            Coordinates.Y += y;
            Translate();
        }

        public void Translate()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                CalculatedPoints[i].X += Coordinates.X;
                CalculatedPoints[i].Y += Coordinates.Y;
            }
        }

        public void MoveForward(double distance)
        {
            Coordinates.X -= distance * Math.Sin(-Angle * Math.PI / 180);
            Coordinates.Y -= distance * Math.Cos(-Angle * Math.PI / 180);

            for (int i=0; i<Points.Count; i++)
            {
                CalculatedPoints[i].X -= distance * Math.Sin(-Angle * Math.PI / 180);
                CalculatedPoints[i].Y -= distance * Math.Cos(-Angle * Math.PI / 180);
            }
        }

        
    }
}
