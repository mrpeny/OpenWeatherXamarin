﻿using OpenWeatherMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(OpenWeatherMobile.Services.OpenWeatherRequestService))]
namespace OpenWeatherMobile.Services
{
    class OpenWeatherRequestService : IWeatherRequestService
    {
        private const int COD_OK = 200;

        private readonly OpenWeatherNetworkUtils openWeatherNetworkUtils;
        private readonly OpenWeatherJsonParser openWeatherJsonParser;

        public OpenWeatherRequestService()
        {
            this.openWeatherNetworkUtils = new OpenWeatherNetworkUtils();
            this.openWeatherJsonParser = new OpenWeatherJsonParser();
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
