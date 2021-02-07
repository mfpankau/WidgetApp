using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;

namespace WeatherWidget
{
    class Program
    {
        static string IPAddress;
        public static float latitude;
        public static float longitude;
        private static int f;

        public static double temperature;
        public static string current;

        private static int ToF(double K)
        {
            return f = ((int)Math.Round(((K - 273.15) * 9.0 / 5.0) + 32.0));
                //(K - 273.15) * 9/5 + 32 = F
        }

        public static void GetWeather()
        {
            GetLocation();
            WeatherInfo weather = new WeatherInfo();
            WebRequest www = WebRequest.Create(requestUriString: $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid=791b3030cbeeb22f892c493abf059750");
            string result = "";
            WebResponse resp = www.GetResponse();
            using (Stream dataStream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
            }
            weather = (WeatherInfo)JsonConvert.DeserializeObject<WeatherInfo>(result);

            temperature = ToF(weather.main.temp);
            current = weather.weather[0].main;
        }



        public static void GetLocation()
        {
            GetIP();
            LocationInfo Info = new LocationInfo();
            string wwwServer = "";
            WebRequest www = WebRequest.Create(requestUriString: $"http://ip-api.com/json/{IPAddress}");
            WebResponse resp = www.GetResponse();
            using (Stream dataStream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                wwwServer = reader.ReadToEnd();
            }
            Info = JsonConvert.DeserializeObject<LocationInfo>(wwwServer);
            latitude = Info.lat;
            longitude = Info.lon;

        }
        private static void GetIP()
        {
            WebRequest request = WebRequest.Create("https://bot.whatismyipaddress.com/");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                IPAddress = (responseFromServer);
            }
        }

        static void Main()
        {
            GetWeather();
            //Print the temp in F
            Console.WriteLine(temperature);
            //Print the current precipitation e.g (snow, rain, sun, clouds)
            Console.WriteLine(current);
        }


    }

    [Serializable]
    public class WeatherInfo
    {
        public Coord coord;
        [JsonProperty("weather")]
        public Weather[] weather;
        public Main main;

    }

    [Serializable]
    public class Main
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public float pressure;
        public float humidity;
    }

    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    [Serializable]
    public class Coord
    {
        public float latitude;
        public float longitude;
    }

    [Serializable]
    public class LocationInfo
    {
        public string status;
        public string country;
        public string countryCode;
        public string region;
        public string regionName;
        public string city;
        public string zip;
        public float lat;
        public float lon;
        public string timezone;
        public string isp;
        public string org;
        public string @as;
        public string query;
    }
}
