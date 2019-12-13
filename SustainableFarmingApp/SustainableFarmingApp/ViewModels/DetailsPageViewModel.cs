using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SustainableFarmingApp.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        public const string VegDetailsKey = "VegDetails";

        public DetailsPageViewModel(INavigationService navigationService)
           : base(navigationService)
        {


        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            VegDetail = parameters.GetValue<VegDetail>(VegDetailsKey);
        }
        private  VegDetail _vegDetail;
        private IVegDatabase _vegDatabase;

        public VegDetail VegDetail
        {
            get { return _vegDetail; }
            set { SetProperty(ref _vegDetail, value); }
        }
    }
}
