using OpenWeatherMobile.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace OpenWeatherMobile.ViewModels
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly string PROPERTY_RESPONSE_TEXT = "ResponseText";

        public string CityName { get; set; }
        public string Details { get; set; }        
        
        public IWeatherRequestService OpenWeatherRequestService => DependencyService.Get<IWeatherRequestService>();

        public MainViewModel()
        {
            Title = Resources.AppResources.Title;
            Details = Resources.AppResources.Details;
            ResponseText = Resources.AppResources.InitialMessage;

            SearchCommand = new Command<string>((key) => ShowTemperatureIn(CityName));
            DetailsCommand = new Command<string>((key) => Device.OpenUri(new Uri("https://openweathermap.org/find?q=" + CityName)));            
        }

        private String responseText;
        public String ResponseText
        {
            set
            {
                if(responseText != value)
                {
                    responseText = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(PROPERTY_RESPONSE_TEXT));
                    }
                }
            }
            get
            {
                return responseText;
            }
        }

        public ICommand SearchCommand { protected set; get; }

        public ICommand DetailsCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        async void ShowTemperatureIn(String city)
        {
            if(String.IsNullOrEmpty(city))
            {
                ResponseText = Resources.AppResources.EnterCityName;
                return;
            }
            double temperature = await OpenWeatherRequestService.getTemperatureByCity(city);
            ResponseText = BuildResponseText(city, temperature);            
        }

        private String BuildResponseText(String cityName, Double temperature)
        {
            String message = null;
            if (double.IsNaN(temperature))
            {
                message = Resources.AppResources.ErrorWrongCity;
            }
            else
            {
                message = String.Format(Resources.AppResources.ResultTemperatureText, cityName, Math.Round(temperature));
            }

            return message;
        }
    }
}
