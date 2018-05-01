using OpenWeatherMobile.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace OpenWeatherMobile.ViewModels
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Instruction { get; set;  } = "Enter city name to search current temperature for!";
        public string CityName { get; set; }
        private String responseText;
   
        OpenWeatherRequestService openWeatherRequestService;

        public MainViewModel()
        {
            Title = "Weather Service";       
            SearchCommand = new Command<string>((key) => ShowTemperatureIn(CityName));
            openWeatherRequestService = new OpenWeatherRequestService(new OpenWeatherNetworkUtils(), new OpenWeatherJsonParser());
        }

        public String ResponseText
        {
            set
            {
                if(responseText != value)
                {
                    responseText = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ResponseText"));
                    }
                }
            }
            get
            {
                return responseText;
            }
        }

        public ICommand SearchCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        async void ShowTemperatureIn(String city)
        {
            if(String.IsNullOrEmpty(city))
            {
                ResponseText = "Please enter a city name!";
                return;
            }
            double temperature = await openWeatherRequestService.getTemperatureByCity(city);
            ResponseText = BuildResponseText(city, temperature);
        }

        private String BuildResponseText(String cityName, Double temperature)
        {
            String message = null;
            if (double.IsNaN(temperature))
            {
                message = "Error occured. Make sure you entered correct city name!";
            }
            else
            {
                message = "Temperature in " + cityName + " is " + Math.Round(temperature) + " °C";
            }

            return message;
        }
    }
}
