using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiWheater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiWheater.Models.CityForecast;

namespace MauiWheater.ViewModels
{
    [QueryProperty(nameof(Daily), nameof(Daily))]
    [QueryProperty(nameof(City), nameof(City))]
    [ObservableObject]
    public partial class DailyForecastViewModel
    {
        public DailyForecastViewModel() { }
        [ObservableProperty]
        SearchedCity city;
        [ObservableProperty]
        Root daily;
        [RelayCommand]
        public void Testando()
        {
            return;
        }
    }
}
