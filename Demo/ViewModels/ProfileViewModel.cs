using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class ProfileViewModel : ObservableObject
    {
        public Command LoadProfileDataCommand { get; set; }

        public Command UpdateProfileDataCommand { get; set; }

        public Command validateNameCommand { get; set; }

        public Command validatePasswordCommand { get; set; }

        bool saveEnabeled;

        public bool SaveEnabeled
        {
            get { return saveEnabeled; }
            set { SetProperty(ref saveEnabeled, value); }
        }

        Profile profileData;

        public Profile ProfileData
        {
            get { return profileData; }
            set { SetProperty(ref profileData, value); }
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

        /* public ICommand ConfirmPasswordCommand { get; set; }*/

        public ProfileViewModel()
        {
            SaveEnabeled = false;
            Console.WriteLine(Int32.Parse(Application.Current.Properties["id"].ToString()));

            UpdateProfileDataCommand = new Command(async async => await SaveProfile());
            LoadProfileDataCommand = new Command(async async => await ProfileDataCommand());

            LoadProfileDataCommand.Execute(null);

            validateNameCommand = new Command(namevalidate);
            validatePasswordCommand = new Command(passwordvalidate);

            /* ConfirmPasswordCommand = new Command<string>((x) => ConfirmPassword(x));*/

        }

        public void namevalidate()
        {
            if (ProfileData.Name != null && Regex.IsMatch(ProfileData.Name, @"^[a-zA-Z]+$"))
            {
                NameError = false;
            }
            else
            {
                NameError = true;
            }
        }

        public void passwordvalidate()
        {
            if (ProfileData.Password != null && Regex.IsMatch(ProfileData.Password, @"^[a-zA-Z]+$"))
            {
                PasswordError = false;
            }
            else
            {
                PasswordError = true;
            }
        }

        async System.Threading.Tasks.Task ProfileDataCommand()
        {
            int id = Int32.Parse(Application.Current.Properties["id"].ToString());

            
        

            ProfileData = await APIServices.GetProfileData(Constants.profileEndpoint, id);
        }

        async System.Threading.Tasks.Task SaveProfile()
        {
            int id = Int32.Parse(Application.Current.Properties["id"].ToString());

            if (PasswordError == false && NameError == false)
            {

                bool success = await APIServices.UpdateUser(id,ProfileData.Name,ProfileData.Password, Constants.updateProfileEndPoint);

                if (success)
                {
                    await Application.Current.MainPage.DisplayAlert("Updated", "Successful", "OK");
                    await ProfileDataCommand();
                }
                else
                {

                    await Application.Current.MainPage.DisplayAlert("Update Failed", "Try Again", "OK");
                }
            }
            else
            {

                await Application.Current.MainPage.DisplayAlert("Invalid Input", "Enter Again", "OK");
            }


            ProfileData = await APIServices.GetProfileData(Constants.profileEndpoint, id);
        }


        /* private async void ConfirmPassword(string password)
         {
             string oldPassowrd = "hello";
             string newPassword = password;
             if (oldPassowrd != newPassword)
             {

                 await Application.Current.MainPage.DisplayAlert("Alert", "Your password doesnot match", "OK");
             }
             else
             {
                 SaveEnabeled = true;
             }
         }*/
    }
}
