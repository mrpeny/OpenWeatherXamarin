using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMobile.Services
{
    interface IWeatherRequestService
    {
        Task<Double> getTemperatureByCity(String cityName);
    }
}
