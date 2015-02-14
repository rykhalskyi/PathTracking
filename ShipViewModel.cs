using Windows.Foundation;
using Windows.UI.Xaml.Media;
using MyBase;

namespace PathTracking
{
    public class ShipViewModel: BaseViewModel
    {
        private IAirCraft _shipDrawer = new BaseAirCraft();

        private const string FrameString = "M 0,0 L 100,0 L 100,100 L 0,100 Z ";
        private string _content = FrameString;
        public string Content
        {
            get 
            {
                return _content;
            }
            private set { _content = value; }
        }

        public ShipViewModel()
        {
        }
        
        public ShipViewModel(IAirCraft shipDrawer)
        {
            _shipDrawer = shipDrawer;
        }

        private string DrawFrame()
        {
            return FrameString;
        }

        
        public void DrawShip(double x, double y)
        {
            _shipDrawer.Rotate(30);
            _shipDrawer.Translate(x, y);
            
            Content = DrawFrame();
            Content += _shipDrawer.DrawShip();
            FireEvent("Content");
        }

        public void Move(double distance)
        {
            _shipDrawer.MoveForward(distance);

            Content = DrawFrame();
            Content += _shipDrawer.DrawShip();
            FireEvent("Content");
        }

        public void Rotate(double angle)
        {
            _shipDrawer.Rotate(angle);
            _shipDrawer.Translate();
            Content = DrawFrame();
            Content += _shipDrawer.DrawShip();
            FireEvent("Content");
        }
    }
}
