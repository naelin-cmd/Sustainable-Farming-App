using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SustainableFarmingApp.ViewModels
{
    public class DonationPageViewModel : ViewModelBase
    {
        private DelegateCommand _donate;
        public DelegateCommand Donate =>
            _donate ?? (_donate = new DelegateCommand(ExecuteDonate));

        private DelegateCommand _location;
        public DelegateCommand Location =>
            _location ?? (_location = new DelegateCommand(ExecuteLocation));

        async void ExecuteLocation()
        {
            await NavigationService.NavigateAsync("Maps");
        }

        async void ExecuteDonate()
        {
            await _vegDatabase.InsertVegOrders(VeggieOrders);

        }
        private VeggieOrders veggieOrders;
        private IVegDatabase _vegDatabase;

        public VeggieOrders VeggieOrders
        {
            get { return veggieOrders; }
            set { SetProperty(ref veggieOrders, value); }
        }

        public DonationPageViewModel (INavigationService navigationservice, IVegDatabase database)
            :base(navigationservice)
        {
            
            var veggieorders = new VeggieOrders();
            VeggieOrders = veggieorders;


            _vegDatabase = database;
        }
    }
}
