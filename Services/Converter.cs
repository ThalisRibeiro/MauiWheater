using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiWheater.Models;
using Newtonsoft.Json;
using static MauiWheater.Models.CityForecast;

namespace MauiWheater.Services
{
    public class Converter
    {
        public List<SearchedCity> ToSearchedCity(string json)
        {
            try
            {
                var ListOfCities = JsonConvert.DeserializeObject<List<SearchedCity>>(json);
                return ListOfCities;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public Root toDailyForecast(string json)
        {
            try
            {
                var DForecast = JsonConvert.DeserializeObject<Root>(json);
                return DForecast;
            }
            catch (Exception)
            {
                throw;
                throw;
            }
        }
    }
}
