using System;
using System.Windows.Input;
using Demo.Models;
using Demo.Services;
using Demo.Views;
using MvvmHelpers;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class ProductDetailViewModel : ObservableObject
    {
        private Items _product;
        public Items Product
        {
            get => _product;
            set
            {
                SetProperty(ref _product, value);
            }
        }

        private AcceptRejectDesign _a;
        public AcceptRejectDesign A
        {
            get => _a;
            set
            {
                SetProperty(ref _a, value);
            }
        }

        private bool result;
        public bool Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }

        }

        public ICommand AcceptPressedCommand { get; set; }

        public ICommand RejectPressedCommand { get; set; }

        public ProductDetailViewModel(Items product,AcceptRejectDesign a)
        {
            this.Product = product;
            this.A = a;

            AcceptPressedCommand = new Command<StatusUpdateModel>(async (x) => await AcceptCommand(x));

            RejectPressedCommand = new Command<StatusUpdateModel>(async (x) => await RejectCommand(x));
        }

        async System.Threading.Tasks.Task AcceptCommand(StatusUpdateModel s)
        {
            result = await APIServices.UpdateStatus(s,Constants.updateProductStatusEndpoint);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Product Accepeted", "ok");
                await Application.Current.MainPage.Navigation.PushAsync(new ProductView(3, "Aprroved Product"));
            }
            else {
                await Application.Current.MainPage.DisplayAlert("Error", "Please try again", "ok");
            }
        }

        async System.Threading.Tasks.Task RejectCommand(StatusUpdateModel s)
        {
            result = await APIServices.UpdateStatus(s, Constants.updateProductStatusEndpoint);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Product Rejected", "ok");
                await Application.Current.MainPage.Navigation.PushAsync(new ProductView(2, "Pending Product"));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please try again", "ok");
            }
        }

    }
}
