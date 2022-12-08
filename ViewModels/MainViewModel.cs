using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiWheater.Models;
using MauiWheater.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWheater.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        public MainViewModel()
        {
            SearchedCities= new ObservableCollection<SearchedCity>();
        }
        [ObservableProperty]
        string searchString;
        [ObservableProperty]
        string apiKey;
        [ObservableProperty]
        public ObservableCollection<SearchedCity> searchedCities;

        [RelayCommand]
        public void SearchCity()
        {
            //searchedCities= new ObservableCollection<SearchedCity>();   
            Api.ApiKey = apiKey;
            var result = Api.SearchCity(searchString);
            var json = Api.JsonContent;
            Converter cv = new Converter();
            //searchedCities.AddRange(cv.ToSearchedCity(json));
            adding(cv.ToSearchedCity(json));
            //searchedCities= cv.ToSearchedCity(json);
        }
        void adding(List<SearchedCity> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                searchedCities.Add(cities[i]);
            }
        }
        bool canSearch()
        {
            if (apiKey != "" && searchString != "")
                return true;
            return false;
        }
    }
}
