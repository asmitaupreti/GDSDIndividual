using Demo.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo.Views
{
    public partial class LoginPage : ContentPage
    {

        LoginViewModel viewModel = new LoginViewModel();
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        private void OnLoginClicked(object sender, EventArgs e)
        {

            Console.WriteLine(viewModel.LoginData.Email);
            Console.WriteLine(viewModel.LoginData.Password);
            viewModel.validateNameCommand.Execute(null);
            viewModel.validatePasswordCommand.Execute(null);
            viewModel.LoadLoginCommand.Execute(null);

        }
    }
}
