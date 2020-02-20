using System;
using System.Collections.ObjectModel;
using System.Diagnostics;


using Xamarin.Forms;

using Demo.Models;
using Demo.Views;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmHelpers;
using Demo.Services;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
    public class ItemsViewModel : ObservableObject
    {
        public Command LoadProductDataCommand { get; set; }

        public Command LoadProductNumberCommand { get; set; }

        public Command LoadBarChartDataCommand { get; set; }


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

        private ObservableCollection<Items> cardsCollection;

        public ObservableCollection<Items> CardsCollection
        {

            get
            {
                if (cardsCollection == null) CardsCollection = new ObservableCollection<Items>();
                return cardsCollection;
            }


            set
            {
                SetProperty(ref cardsCollection, value);

            }
        }

        private ObservableCollection<BarChartModel> data;

        public ObservableCollection<BarChartModel> Data
        {

            get
            {
                if (data == null) Data = new ObservableCollection<BarChartModel>();
                return data;
            }


            set
            {
                SetProperty(ref data, value);

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

        /*private ObservableCollection<Person> data;

        public ObservableCollection<Person> Data
        {

            get
            {
                if (data == null) Data = new ObservableCollection<Person>();
                return data;
            }


            set
            {
                SetProperty(ref data, value);

            }
        }*/

        public ICommand SelectionCommand => new Command(ItemSelected);


        public ItemsViewModel()
        {
            IsLoading = true;
            LoadProductDataCommand = new Command(async async => await ProfileDataCommand());
            LoadProductDataCommand.Execute(null);

            LoadProductNumberCommand = new Command(async async => await ProductNumberDataCommand());
            LoadProductNumberCommand.Execute(null);

            LoadBarChartDataCommand = new Command(async async => await BarChartDataCommand());
            LoadBarChartDataCommand.Execute(null);




            
        }

        async System.Threading.Tasks.Task ProfileDataCommand()
        {
            ItemsCollection = await APIServices.GetProductData(Constants.productEndpoint);
            IsLoading = false;

        }

        async System.Threading.Tasks.Task ProductNumberDataCommand()
        {
            CardsCollection = await APIServices.GetProductNumber(Constants.productMenuEndPoint);
            IsLoading = false;

        }

        async System.Threading.Tasks.Task BarChartDataCommand()
        {
            Data = await APIServices.GetBarChartData(Constants.barChartEndpoint);
        }






        private async void ItemSelected()
        {
            if (Selection != null)
            {
                var adminPage = Selection.Id;
                Console.WriteLine(adminPage);
                switch (adminPage)
                {
                    case 1:
                        var detailPage1 = new ProductView(1);
                        await Shell.Current.Navigation.PushAsync(detailPage1);
                        Selection = null;
                        break;
                    case 2:
                        var detailPage2 = new ProductView(2);
                        await Shell.Current.Navigation.PushAsync(detailPage2);
                        Selection = null;
                        break;
                    case 3:
                        var detailPage3 = new ProductView(3);
                        await Shell.Current.Navigation.PushAsync(detailPage3);
                        Selection = null;
                        break;
                    case 4:
                        var detailPage4 = new UsersView(1);
                        await Shell.Current.Navigation.PushAsync(detailPage4);
                        Selection = null;
                        break;

                    case 5:
                        var detailPage5 = new UsersView(2);
                        await Shell.Current.Navigation.PushAsync(detailPage5);
                        Selection = null;
                        break;

                    case 6:
                        var detailPage6 = new UsersView(3);
                        await Shell.Current.Navigation.PushAsync(detailPage6);
                        Selection = null;
                        break;

                }
            }
        }

    }

}
