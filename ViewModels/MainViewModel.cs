using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiWheater.Models;
using MauiWheater.Services;
using MauiWheater.Views;
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

        [ObservableProperty]
        public SearchedCity selectedCity;

        [RelayCommand]
        public void SearchCity()
        {
            if (canSearch() == false)
                return;
            Api.ApiKey = apiKey;
            var result = Api.SearchCity(searchString);
            if (result.Status == TaskStatus.Faulted)
            {
                //enviar mensagem que ocorreu algum erro ao buscar os dados da api
                return;
            }
            var json = Api.JsonContent;
            Converter cv = new Converter();
            adding(cv.ToSearchedCity(json));
        }
        [RelayCommand]
        public void SearchDaily(/*SearchedCity city*/)
        {
            var result = Api.GetInfoCity(selectedCity.CityKey);
            if (result.Status == TaskStatus.Faulted)
            {
                //enviar mensagem que ocorreu algum erro ao buscar os dados da api
                return;
            }
            var json = Api.JsonContent;
            ConvertingToDaily(in json);
            _ = goToDailyForecastPageAsync();

        }
        void ConvertingToDaily(in string json)
        {
            var cv = new Converter();
            var Daily = cv.toDailyForecast(json);
        }
        void adding(List<SearchedCity> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                searchedCities.Add(cities[i]);
            }
        }
        async Task goToDailyForecastPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(DailyForecastPage));
        }
        bool canSearch()
        {
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(searchString))
                return false;
            return true;
        }
    }
}
