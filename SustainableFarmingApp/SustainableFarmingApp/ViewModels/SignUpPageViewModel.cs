using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SustainableFarmingApp.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private IVegDatabase _vegDatabase;

        private DelegateCommand _save;
        public DelegateCommand CommandSave =>
            _save ?? (_save = new DelegateCommand(ExecuteCommandSave));

        private DelegateCommand _delete;
        public DelegateCommand CommandDelete =>
            _delete ?? (_delete = new DelegateCommand(ExecuteCommandDelete));

        private User _latestuser;
        public User LatestUser
        {
            get { return _latestuser; }
            set { SetProperty(ref _latestuser, value); }
        }




        private async void ExecuteCommandDelete()
        {
            await NavigationService.NavigateAsync("MainPage");
        }

        private async void ExecuteCommandSave()
        {
            await _vegDatabase.InsertUser(LatestUser);

        }



        public SignUpPageViewModel(INavigationService navigationService, IVegDatabase vegDatabase) : base(navigationService)
        {
            Title = "SignUp Page";
            _vegDatabase = vegDatabase;
            var userClass = new User();
            LatestUser = userClass;

            PostUserList();


        }
        public async void PostUserList()
        {
            var db = new VegDetailsDatabase();
            var dbUserList = await db.GetUserList();
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/Users";

            for (int i = 0; i < dbUserList.Count; i++)
            {
                var json = JsonConvert.SerializeObject(dbUserList[i]);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(url, content);
            }


            }
        }
}
