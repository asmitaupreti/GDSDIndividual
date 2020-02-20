using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class UserViewModel : ObservableObject
    {
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


        public UserViewModel(int number)
        {
            IsLoading = true;

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
    }
}