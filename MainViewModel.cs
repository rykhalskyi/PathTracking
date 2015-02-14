using System;
using System.Windows.Input;
using MyBase;
using System.Collections.ObjectModel;

namespace PathTracking
{
    class MainViewModel
    {
        private ObservableCollection<CheckPoint> _checkPoints = new ObservableCollection<CheckPoint>();
        public ObservableCollection<CheckPoint> CheckPoints
        {
            get { return _checkPoints; }
        }

        public MainViewModel()
        {
            CheckPoints.Add(new CheckPoint(20, 20));
            CheckPoints.Add(new CheckPoint(20, 40));
            CheckPoints.Add(new CheckPoint(30, 50));
            CheckPoints.Add(new CheckPoint(60, 50));
            CheckPoints.Add(new CheckPoint(80, 20));

            foreach (var checkpoint in CheckPoints)
            { checkpoint.DrawCheckPoint(); }
        }

        private ICommand _drawVesselCommand = null;
        public ICommand DrawVesselCommand
        {
            get
            {
                if (_drawVesselCommand == null)
                {
                    _drawVesselCommand = new RelayCommand(a => DrawVessel()); 
                }
                return _drawVesselCommand;
            }
        }

        private ICommand _rotateCommand = null;
        public ICommand RotateCommand
        {
            get
            {
                if (_rotateCommand == null)
                {
                    _rotateCommand = new RelayCommand(a => RotateVessel());
                }
                return _rotateCommand;
            }
        }

        private ICommand _moveCommand = null;
        public ICommand MoveCommand
        {
            get
            {
                if (_moveCommand == null)
                {
                    _moveCommand = new RelayCommand(a => MoveVessel());
                }
                return _moveCommand;
            }
        }



        private ShipViewModel _ship = new ShipViewModel(new SimpleShipDrawer());
        public ShipViewModel Ship
        {
            get { return _ship; }
        }

        private void DrawVessel()
        {
            Ship.DrawShip(50, 50);
        }

        private void MoveVessel()
        {
            Ship.Move(1);
        }

        private void RotateVessel()
        {
            Ship.Rotate(30);
        }
    }
}
