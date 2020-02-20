using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class UsersView : ContentPage
    {
        UserViewModel viewModel;

        int number;

        StatusUpdateModel s = new StatusUpdateModel();
        public UsersView(int num, string title)
        {
            InitializeComponent();
            number = num;
            BindingContext = viewModel = new UserViewModel(num, title);
        }

        private void Accept_Tapped(object sender, EventArgs e)
        {

            if (number == 3)
            {
                Application.Current.MainPage.DisplayAlert("Info", "User is already accept ", "ok");
            }
            else {
                var swipped = sender as Grid;
                var classId = swipped.ClassId;

                s.id = Int32.Parse(classId);
                s.status = "1";
                viewModel.AcceptPressedCommand.Execute(s);

                Console.WriteLine(classId);
            }
            

        }

        private void Delete_Tapped(object sender, EventArgs e)
        {

            if (number == 2)
            {
                Application.Current.MainPage.DisplayAlert("Info", "User is not accepted to block ", "ok");
            }
            else {
                var swipped = sender as Grid;
                var classId = swipped.ClassId;
                s.id = Int32.Parse(classId);
                s.status = "0";
                viewModel.RejectPressedCommand.Execute(s);
            }
        }
    }
}
