using System;
using System.Collections.Generic;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class UsersView : ContentPage
    {
        UserViewModel viewModel;
        public UsersView(int num)
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel(num);
        }

        private void Accept_Tapped(object sender, EventArgs e)
        {
            var swipped = sender as Grid;
            var classId = swipped.ClassId;
            Console.WriteLine(classId);

        }

        private void Delete_Tapped(object sender, EventArgs e)
        {
            var swipped = sender as Grid;
            var classId = swipped.ClassId;
            Console.WriteLine(classId);

        }
    }
}
