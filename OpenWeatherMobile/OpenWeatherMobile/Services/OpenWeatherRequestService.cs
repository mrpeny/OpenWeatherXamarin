using OpenWeatherMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMobile.Services
{
    class OpenWeatherRequestService : IWeatherRequestService
    {
        private OpenWeatherNetworkUtils openWeatherNetworkUtils;
        private OpenWeatherJsonParser openWeatherJsonParser;

        public OpenWeatherRequestService(OpenWeatherNetworkUtils networkUtils, OpenWeatherJsonParser jsonParser)
        {
            this.openWeatherNetworkUtils = networkUtils;
            this.openWeatherJsonParser = jsonParser;
        }


        async public Task<Double> getTemperatureByCity(string cityName)
        {
            var jsonTask = await openWeatherNetworkUtils.GetCityWeatherJson("Budapest");
            CityWeather cityWeather = openWeatherJsonParser.parseCityWeatherFrom(jsonTask);
            if (cityWeather == null)           
            {
                Console.WriteLine("CityWeather null");
                return Double.NaN;
            }

            return cityWeather.MainWeather.Temp;     
        }
    }
}
