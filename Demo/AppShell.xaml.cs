using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Demo.Views;
using Xamarin.Forms;

namespace Demo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

        public AppShell()
        {
            BindingContext = this;

            InitializeComponent();
        }

        private async Task LogoutAsync()
        {
            try
            {

                bool res = await DisplayAlert("Confirm", "Are you sure you want to logout", "Ok", "Cancel");

                if (res)
                {
                    await Current.Navigation.PushModalAsync(new LoginPage());
                }


                //await IndustryViewModel.Current.AuthViewModel.RevokeTokenAsync();
                //await IndustryViewModel.Current.UserViewModel.ResetPermitAsync();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }
        }
    }
}
