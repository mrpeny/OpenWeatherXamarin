using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OpenWeatherMobile.ViewModels
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        double temperature;
        public string Instruction { get; set;  } = "Enter city name to search current temperature for!";

        public MainViewModel()
        {
            Title = "Weather Service";
            
        }

        public MainViewModel(double temperature)
        {
            this.temperature = temperature;
        }

        public double Temperature
        {
            set
            {
                if (temperature != value)
                {
                    temperature = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("temperature"));
                    }
                }
            }
            get
            {
                return temperature;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
