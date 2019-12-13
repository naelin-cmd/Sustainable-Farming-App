using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SustainableFarmingApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _login;
        public DelegateCommand LoginCommand =>
            _login ?? (_login = new DelegateCommand(ExecuteLoginCommand));

        private DelegateCommand _signup;
        public DelegateCommand SignUpCommand =>
            _signup ?? (_signup = new DelegateCommand(ExecuteSignUpCommand));
             private User _latestuser;
        public User LatestUser
        {
            get { return _latestuser; }
            set { SetProperty(ref _latestuser, value); }
        }


        private async void ExecuteSignUpCommand()
        {
            await NavigationService.NavigateAsync("SignUpPage");

        }

        private async void ExecuteLoginCommand()
        {

           
            var conn = new VegDetailsDatabase();
            var users= await conn.GetItemsAsync();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Password == LatestUser.Password && users[i].Name == LatestUser.Name)
                {

                    await NavigationService.NavigateAsync("MasterPage/NavigationPage/FarmingDetails", useModalNavigation: true) ;
                  

                }

            }
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)

        {
            Title = "Login";
            
            var userClass = new User();
            LatestUser = userClass;
        }
    }
}
