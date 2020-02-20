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

        AcceptRejectDesign a = new AcceptRejectDesign();

        int number;
        public ProductView(int num, string title)
        {
            InitializeComponent();
            number = num;
            BindingContext = viewModel = new ProductViewModel(num,title);
        }

        private async void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {

            if (number == 1)
            {
                a.StackVisible = false;
                a.AcceptVisible = false;
                a.RejectVisible = false;
            }
            else if (number == 2)
            {
                a.StackVisible = true;
                a.AcceptVisible = true;
                a.RejectVisible = false;
            }
            else {
                a.StackVisible = true;
                a.AcceptVisible = false;
                a.RejectVisible = true;
            }



            var postDetailPage = new ProductDetailView(e.ItemData as Items , a);
            await Navigation.PushAsync(postDetailPage);
            viewModel.Selection = null;
        }
    }
}
