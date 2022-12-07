using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiWheater.Models;
using Newtonsoft.Json;
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
    }
}
