# OpenWeather Mobile Demo app
A Xamarin Demo app that connects to OpenWeatherMap web API and shows current temperature in a given city.

## Technology
* .NET Standard 2.0
* Xamarin.Forms and XAML
* Model - View - ViewModel architecture with binded properties and commands
* DependencyService IoC container

## Notes
### API Key
OpenWeather API Key should be placed in OpenWeatherNetworkUtils.cs as a value of PARAM_VALUE_APP_ID. e.g.: 
```
private const String PARAM_VALUE_APP_ID = "1234aabbccdd5678eeffgghh910";
```