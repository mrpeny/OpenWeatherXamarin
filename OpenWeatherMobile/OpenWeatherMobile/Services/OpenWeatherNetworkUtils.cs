﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace OpenWeatherMobile.Services
{
    public class OpenWeatherNetworkUtils
    {
        private const string PARAM_KEY_APP_ID = "APPID";
        // TODO: Insert your API key her
        private const String PARAM_VALUE_APP_ID = "insert-your-api-key-here";

        private const String PARAM_KEY_UNITS = "units";
        private const String PARAM_VALUE_UNITS = "metric";
        private const String PARAM_KEY_CITY = "q";

        private const String BASE_API_URI_OWM = "http://api.openweathermap.org/data/2.5/weather";

        public async Task<Stream> GetCityWeatherJson(String city)
        {
            if (String.IsNullOrEmpty(city))
            {
                return null;
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            string uriString = BASE_API_URI_OWM + "?" + PARAM_KEY_CITY + "=" + city + "&" + PARAM_KEY_UNITS + "=" + PARAM_VALUE_UNITS +
                "&" + PARAM_KEY_APP_ID + "=" + PARAM_VALUE_APP_ID;

            try
            {
                Stream streamTask = await client.GetStreamAsync(uriString);
                return streamTask;       
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return null;
            }            
        }
    }
}
