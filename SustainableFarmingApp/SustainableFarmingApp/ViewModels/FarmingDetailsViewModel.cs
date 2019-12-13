using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SustainableFarmingApp.ViewModels
{
    public class FarmingDetailsViewModel : ViewModelBase
    {
        private DelegateCommand<VegDetail> _vegdetail;
        public DelegateCommand<VegDetail> VegDetailCommand =>
            _vegdetail ?? ( _vegdetail = new DelegateCommand<VegDetail>(ExecuteVegDetailCommand));
        private DelegateCommand _search;
        public DelegateCommand Search =>
            _search ?? (_search = new DelegateCommand(ExecuteSearch));

        void ExecuteSearch()
        {
            

        }
        async void ExecuteVegDetailCommand(VegDetail vegDetail)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(DetailsPageViewModel.VegDetailsKey, vegDetail);
            await NavigationService.NavigateAsync("DetailsPage", navigationParams);

        }
        private ObservableCollection<VegDetail> vegDetails;
        private IVegDatabase _vegDatabase;

        public ObservableCollection<VegDetail> VegDetails
        {
            get { return vegDetails; }
            set { SetProperty(ref vegDetails, value); }
        }
        public FarmingDetailsViewModel(INavigationService navigationService, IVegDatabase vegDatabase)
            : base(navigationService)
        {
            _vegDatabase = vegDatabase;
            PostVegList();
        }

        public async void PostVegList()
        {
            
                var db = new VegDetailsDatabase();
                var dbVegList = await db.GetVegDetails();
                var client = new HttpClient();
                var url = "http://10.0.2.2:5000/VegDetails";

                for (int i = 0; i < dbVegList.Count; i++)
                {
                    var json = JsonConvert.SerializeObject(dbVegList[i]);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync(url, content);




                }
            



        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var vegdetails = await _vegDatabase.GetVegDetails();
            VegDetails = new ObservableCollection<VegDetail>(vegdetails);
        }

      

    }
}
