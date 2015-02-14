﻿using System;
using System.ComponentModel;

namespace MyBase
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void FireEvent(string param)
        {
            if (param != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));
            }
        }

    }
}
