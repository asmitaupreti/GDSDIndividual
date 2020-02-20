using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public Command LoadLoginCommand { get; set; }

        private loginModel loginData;

        public loginModel LoginData
        {
            get
            {
                return loginData;
            }

            set
            {
                SetProperty(ref loginData, value); ;
            }
        }

        private loginModel responseloginData;

        public loginModel ResponseloginData
        {
            get
            {
                return responseloginData;
            }

            set
            {
                SetProperty(ref responseloginData, value); ;
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                SetProperty(ref isLoading, value);
            }
        }




        public LoginViewModel()
        {

            LoginData = new loginModel();
            ResponseloginData = new loginModel();
            LoadLoginCommand = new Command(async async => await LoginDataCommand());

        }

        async System.Threading.Tasks.Task LoginDataCommand()
        {
            bool success = await APIServices.LoginUser(LoginData.Email, LoginData.Password, Constants.loginEndpoint);

            if (success)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {

                await Application.Current.MainPage.DisplayAlert("Login Failed", "Try Again", "OK");
            }

        }



    }
}