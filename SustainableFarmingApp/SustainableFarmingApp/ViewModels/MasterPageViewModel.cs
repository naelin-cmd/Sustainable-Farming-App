using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SustainableFarmingApp.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
        
    {
        private DelegateCommand _home;
        public DelegateCommand Home =>
            _home ?? (_home = new DelegateCommand(ExecuteHome));
        private DelegateCommand _location;
        public DelegateCommand Location =>
            _location ?? (_location = new DelegateCommand(ExecuteLocation));

        private DelegateCommand _signup;
        public DelegateCommand CommandSignUpName =>
            _signup ?? (_signup = new DelegateCommand(ExecuteCommandSignUpName));
        private DelegateCommand _donate;
        public DelegateCommand Donate =>
            _donate ?? (_donate = new DelegateCommand(ExecuteDonate));

       async void ExecuteDonate()
        {
            await NavigationService.NavigateAsync("NavigationPage/DonationPage");
        }

       async void ExecuteCommandSignUpName()
        {
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        async void ExecuteLocation()
        {
            await NavigationService.NavigateAsync("NavigationPage/Maps");

        }

        private async void ExecuteHome()
        {
            await NavigationService.NavigateAsync("NavigationPage/FarmingDetails");

        }
        public MasterPageViewModel (INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
