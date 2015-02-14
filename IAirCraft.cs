using System.Collections.Generic;
namespace PathTracking
{
    public interface IAirCraft
    {
        void Rotate(double angle);
        void Translate(double x, double y);
        void Translate();
        void MoveForward(double distance);

        string DrawShip();
    }
}
