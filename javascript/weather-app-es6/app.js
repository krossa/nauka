import * as elements from "elements.js";
import { Http } from "http.js";
import { WeatherData, WEATHER_PROXY_HANDLER } from "weather-data.js";

elements.ELEMENT_SEARCH_BUTTON.addEventListener("click", searchWeather);

function searchWeather() {
  const cityName = elements.ELEMENT_SEARCHED_CITY.value.trim();
  if (cityName.length == 0) {
    return alert("enter city name");
  }

  elements.ELEMENT_LOADING_TEXT.style.display = 'block';

  var apiKey = "540290b951ee190dc80f9d14c3cb4d56";
  var url =
    "http://api.openweathermap.org/data/2.5/weather?q=" +
    cityName +
    "&units=metric&appid=" +
    apiKey;
  Http.fetchData(url)
    .then(responseData => {
      const weatherData = new WeatherData(
        cityName,
        responseData.weather[0].description.toUpperCase()
      );
      const weatherProxy = new Proxy(weatherData, WEATHER_PROXY_HANDLER);
      weatherProxy.temp = responseData.main.temp;
      updateWeather(weatherData);
      elements.ELEMENT_LOADING_TEXT.style.display = 'none';
    })
    .catch(error => alert(error));
}

function updateWeather(weatherData) {
  elements.ELEMENT_LOADING_WEATHER_DESCRIPTION.textContent =
    weatherData.description;
  elements.ELEMENT_LOADING_WEATHER_TEMPERATURE.textContent = weatherData.temp;
  elements.ELEMENT_LOADING_WEATHER_CITY.textContent = weatherData.cityName;

  elements.ELEMENT_LOADING_WEATHER_BOX.style.display = 'block';
}
