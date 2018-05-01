using OpenWeatherMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMobile.Services
{
    class OpenWeatherRequestService : IWeatherRequestService
    {
        private const int COD_OK = 200;

        private OpenWeatherNetworkUtils openWeatherNetworkUtils;
        private OpenWeatherJsonParser openWeatherJsonParser;

        public OpenWeatherRequestService(OpenWeatherNetworkUtils networkUtils, OpenWeatherJsonParser jsonParser)
        {
            this.openWeatherNetworkUtils = networkUtils;
            this.openWeatherJsonParser = jsonParser;
        }

        async public Task<Double> getTemperatureByCity(string cityName)
        {
            var jsonTask = await openWeatherNetworkUtils.GetCityWeatherJson(cityName);
            CityWeather cityWeather = openWeatherJsonParser.parseCityWeatherFrom(jsonTask);
            if (cityWeather == null)           
            {
                Console.WriteLine("CityWeather is null");
                return Double.NaN;
            }
            if (cityWeather.Cod != COD_OK)
            {
                Console.WriteLine("Problem while retrieving data: " + cityWeather.Message);
                return Double.NaN;
            }

            return cityWeather.MainWeather.Temp;     
        }
    }
}
