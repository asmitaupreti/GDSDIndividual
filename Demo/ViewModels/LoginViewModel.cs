using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public Command LoadLoginCommand { get; set; }

        private loginModel loginData;

        public Command validateNameCommand { get; set; }

        public Command validatePasswordCommand { get; set; }

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

        private bool nameError;
        public bool NameError
        {
            get
            {
                return nameError;
            }

            set
            {
                SetProperty(ref nameError, value);
            }
        }

        private bool passwordError;
        public bool PasswordError
        {
            get
            {
                return passwordError;
            }

            set
            {
                SetProperty(ref passwordError, value);
            }
        }




        public LoginViewModel()
        {

            LoginData = new loginModel();
            ResponseloginData = new loginModel();
            LoadLoginCommand = new Command(async async => await LoginDataCommand());
            validateNameCommand = new Command(namevalidate);
            validatePasswordCommand = new Command(passwordvalidate);

        }

        public void namevalidate() {
            if (LoginData.Email != null && Regex.IsMatch(LoginData.Email, @"^[a-zA-Z]+$"))
            {
                NameError = false;
                
            }
            else {
                NameError = true;
            }
        }

        public void passwordvalidate()
        {
            if (LoginData.Password != null && Regex.IsMatch(LoginData.Password, @"^[a-zA-Z]+$"))
            {
                PasswordError = false;
            }
            else
            {
                PasswordError = true;
            }
        }


        async System.Threading.Tasks.Task LoginDataCommand()
        {

            if (PasswordError == false && NameError == false)
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
            else {

                await Application.Current.MainPage.DisplayAlert("Invalid Input","Enter Again", "OK");
            }

            

        }



    }
}