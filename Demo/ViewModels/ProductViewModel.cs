using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        public Command LoadProductDataCommand { get; set; }

        private ObservableCollection<Items> itemsCollection;

        public ObservableCollection<Items> ItemsCollection
        {

            get
            {
                if (itemsCollection == null) ItemsCollection = new ObservableCollection<Items>();
                return itemsCollection;
            }


            set
            {
                SetProperty(ref itemsCollection, value);

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

        private Items _selection;

        public Items Selection
        {
            get { return _selection; }
            set { SetProperty(ref _selection, value); }
        }

        public ProductViewModel(int number)
        {
            IsLoading = true;

            if (number == 1)
            {
                LoadProductDataCommand = new Command(async async => await TotalProductDataCommand());
                LoadProductDataCommand.Execute(null);
            }
            else if (number == 2)
            {
                LoadProductDataCommand = new Command(async async => await PendingProductDataCommand());
                LoadProductDataCommand.Execute(null);

            }
            else
            {
                LoadProductDataCommand = new Command(async async => await ApprovedProductDataCommand());
                LoadProductDataCommand.Execute(null);
            }
        }

        async System.Threading.Tasks.Task TotalProductDataCommand()
        {
            ItemsCollection = await APIServices.GetProductData(Constants.productEndpoint);
            IsLoading = false;

        }

        async System.Threading.Tasks.Task PendingProductDataCommand()
        {
            ItemsCollection = await APIServices.GetProductData(Constants.pendingProductEndpoint);
            IsLoading = false;

        }

        async System.Threading.Tasks.Task ApprovedProductDataCommand()
        {
            ItemsCollection = await APIServices.GetProductData(Constants.approvedProductEndpoint);
            IsLoading = false;

        }




    }

}

