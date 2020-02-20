using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class UserViewModel : ObservableObject
    {
        private bool result;
        public bool Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }

        }

        private ObservableCollection<UserModel> userCollection;

        public ObservableCollection<UserModel> UserCollection
        {

            get
            {
                if (userCollection == null) UserCollection = new ObservableCollection<UserModel>();
                return userCollection;
            }


            set
            {
                SetProperty(ref userCollection, value);

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
                SetProperty(ref isLoading, value); ;
            }
        }
        public Command LoadUserDataCommand { get; set; }

        public ICommand AcceptPressedCommand { get; set; }

        public ICommand RejectPressedCommand { get; set; }
        public UserViewModel(int number)
        {
            IsLoading = true;

            AcceptPressedCommand = new Command<StatusUpdateModel>(async (x) => await AcceptCommand(x));

            RejectPressedCommand = new Command<StatusUpdateModel>(async (x) => await RejectCommand(x));

            if (number == 1)
            {

                LoadUserDataCommand = new Command(async async => await TotalUserDataCommand());
                LoadUserDataCommand.Execute(null);
            }
            else if (number == 2)
            {
                LoadUserDataCommand = new Command(async async => await PendingUserDataCommand());
                LoadUserDataCommand.Execute(null);
            }
            else
            {
                LoadUserDataCommand = new Command(async async => await ApprovedUserDataCommand());
                LoadUserDataCommand.Execute(null);
            }
        }

        async System.Threading.Tasks.Task TotalUserDataCommand()
        {
            UserCollection = await APIServices.GetUserData(Constants.userEndpoint);
            IsLoading = false;
        }

        async System.Threading.Tasks.Task PendingUserDataCommand()
        {
            UserCollection = await APIServices.GetUserData(Constants.pendingUserEndpoint);
            IsLoading = false;
        }

        async System.Threading.Tasks.Task ApprovedUserDataCommand()
        {
            UserCollection = await APIServices.GetUserData(Constants.approvedUserEndpoint);
            IsLoading = false;
        }


        async System.Threading.Tasks.Task AcceptCommand(StatusUpdateModel s)
        {
            result = await APIServices.UpdateStatus(s, Constants.updateUserStatusEndpoint);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Product Accepeted", "ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please try again", "ok");
            }
        }

        async System.Threading.Tasks.Task RejectCommand(StatusUpdateModel s)
        {
            result = await APIServices.UpdateStatus(s, Constants.updateUserStatusEndpoint);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Product Rejected", "ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please try again", "ok");
            }
        }
    }
}