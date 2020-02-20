using System;
using System.Windows.Input;
using Demo.Models;
using MvvmHelpers;
using Xamarin.Forms;


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

        public ICommand AcceptPressedCommand => new Command(AcceptCommand);

        public ICommand RejectPressedCommand => new Command(RejectCommand);

        public ProductDetailViewModel(Items product)
        {
            this.Product = product;
        }

        void AcceptCommand()
        {
            /*ItemsCollection = await APIServices.GetProductData(Constants.productEndpoint);
            IsLoading = false;*/

        }

        void RejectCommand()
        {
            /*ItemsCollection = await APIServices.GetProductData(Constants.productEndpoint);
            IsLoading = false;*/

        }

    }
}
