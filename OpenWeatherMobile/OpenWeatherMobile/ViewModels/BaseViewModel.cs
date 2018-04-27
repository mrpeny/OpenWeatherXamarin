using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenWeatherMobile.ViewModels
{
    class BaseViewModel
    {
        string title = String.Empty;
        public string Title
        {
            get { return title; }
            set { title = value;  }
        }
        
    }
}
