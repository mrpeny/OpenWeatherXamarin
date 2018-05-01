using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OpenWeatherMobile.Models
{
    [DataContract]
    class CityWeather
    {
        public CityWeather() { }

        [DataMember(Name = "cod")]
        public int Cod { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "main")]
        public MainWeather MainWeather { get; set; }
    }
}
