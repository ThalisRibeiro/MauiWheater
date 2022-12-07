using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWheater.Models
{
    public class SearchedCity
    {
        [JsonProperty("LocalizedName")]
        required public string CityName { get; set; }
        [JsonProperty("Key")]
        required public string CityKey { get; set; }

        [JsonProperty("Country")]
        required public Country Country { get; set; }

        override public string ToString()
        {
            return ($"{CityName}, {Country.CountryId}");
        }
    }
    public class Country
    {
        [JsonProperty("LocalizedName")]
        required public string CountryName { get; set; }
        [JsonProperty("ID")]
        required public string CountryId { get; set; }
    }
}
