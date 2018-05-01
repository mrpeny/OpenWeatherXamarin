using OpenWeatherMobile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMobile.Services
{
    class OpenWeatherJsonParser
    {
        public CityWeather parseCityWeatherFrom(Stream jsonStream)
        {
            if(jsonStream == null)
            {
                return null;
            }

            var serializer = new DataContractJsonSerializer(typeof(CityWeather));
            var cityWeather = serializer.ReadObject(jsonStream) as CityWeather;

            return cityWeather;
        }
    }
}
