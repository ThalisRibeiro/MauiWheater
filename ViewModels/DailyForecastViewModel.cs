using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiWheater.Models.CityForecast;

namespace MauiWheater.ViewModels
{
    [ObservableObject]
    public partial class DailyForecastViewModel
    {
        public DailyForecastViewModel() { }

        [ObservableProperty]
        Root root;
    }
}
