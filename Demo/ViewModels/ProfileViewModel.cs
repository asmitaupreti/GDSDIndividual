using System;
using System.Windows.Input;
using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class ProfileViewModel : ObservableObject
    {
        public Command LoadProfileDataCommand { get; set; }

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

        public ICommand ConfirmPasswordCommand { get; set; }

        public ProfileViewModel()
        {
            SaveEnabeled = false;

            LoadProfileDataCommand = new Command(async async => await ProfileDataCommand());

            LoadProfileDataCommand.Execute(null);

            ConfirmPasswordCommand = new Command<string>((x) => ConfirmPassword(x));

        }

        async System.Threading.Tasks.Task ProfileDataCommand()
        {
            ProfileData = await APIServices.GetProfileData(Constants.profileEndpoint);
        }


        private async void ConfirmPassword(string password)
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
        }
    }
}
