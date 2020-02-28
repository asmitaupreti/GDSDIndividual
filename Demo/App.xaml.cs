using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Demo.Services;
using Demo.Views;

namespace Demo
{
    public partial class App : Application
    {
        public static string User = "Rendy";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
