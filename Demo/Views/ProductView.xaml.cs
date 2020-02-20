using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class ProductView : ContentPage
    {
        ProductViewModel viewModel;
        public ProductView(int num)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductViewModel(num);
        }

        private async void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var postDetailPage = new ProductDetailView(e.ItemData as Items);
            await Navigation.PushAsync(postDetailPage);
            viewModel.Selection = null;
        }
    }
}
