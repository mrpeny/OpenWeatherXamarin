using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OpenWeatherMobile.Models
{
    [DataContract]
    class MainWeather
    {
        [DataMember(Name = "temp")]
        public double Temp { get; set; }
    }
}
