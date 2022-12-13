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
using static MauiWheater.Models.CityForecast;

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
            var daily =ConvertingToDaily(in json);
            goToDailyForecastPageAsync(createDictionary(daily));

        }
        Root ConvertingToDaily(in string json)
        {
            var cv = new Converter();
            return cv.toDailyForecast(json);
        }
        void adding(List<SearchedCity> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                searchedCities.Add(cities[i]);
            }
        }
        async Task goToDailyForecastPageAsync(Dictionary<string, object> pairs)
        {
            await Shell.Current.GoToAsync(nameof(DailyForecastPage), pairs);
        }
        bool canSearch()
        {
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(searchString))
                return false;
            return true;
        }
        Dictionary<string,object> createDictionary(Root root)
        {
            return new Dictionary<string, object>
            {
                [nameof(DailyForecastViewModel.City)] = SelectedCity,
                ["Daily"] = root,
            };

        }
    }
}
