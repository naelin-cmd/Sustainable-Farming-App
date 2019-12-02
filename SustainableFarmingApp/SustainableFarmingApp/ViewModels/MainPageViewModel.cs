using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SustainableFarmingApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _login;
        public DelegateCommand Login =>
            _login ?? (_login = new DelegateCommand(ExecuteLogin));

        private DelegateCommand _signup;
        public DelegateCommand SignUp =>
            _signup ?? (_signup = new DelegateCommand(ExecuteSignUp));

        async void ExecuteSignUp()
        {
            await NavigationService.NavigateAsync("SignUp");

        }

        async void ExecuteLogin()
        {
            await NavigationService.NavigateAsync("LoginPage");

        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)

        {
            Title = "Main Page";
        }
    }
}
