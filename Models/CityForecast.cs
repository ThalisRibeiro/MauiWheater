using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWheater.Models
{
    public class CityForecast
    {
        public class Root
        {
            public Headline Headline { get; set; }
            public List<DailyForecast> DailyForecasts { get; set; }
        }
        public class Headline
        {
            public string Text { get; set; }
            public string Category { get; set; }
        }
        public class DailyForecast
        {
            public Temperature Temperature { get; set; }
            public DayNight Day { get; set; }
            public DayNight Night { get; set; }
        }

        public class DayNight
        {
            public int Icon { get; set; }
            public string IconPhrase { get; set; }
            public string IconUri
            {
                get
                {
                    //return $"https://www.accuweather.com/images/weathericons/{Icon}.svg";
                    return $"https://developer.accuweather.com/sites/default/files/{Icon}-s.png";
                }
            }
            public Uri IconUrl
            {
                get
                {
                    Uri uri = new Uri(IconUri);
                    return uri;
                }
            }
        }


        public class Temperature
        {
            public MaxMin Minimum { get; set; }
            public MaxMin Maximum { get; set; }
        }

        public class MaxMin
        {
            public string Value { get; set; }
            public string Unit { get; set; }
            public string UnitType { get; set; }
        }

        public class Images
        {
            public int Icon { get; set; }
            public string link
            {
                get
                {
                    return $"https://www.accuweather.com/images/weathericons/{Icon}.svg";
                }
            }
        }
    }
}
