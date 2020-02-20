using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class ProductDetailView : ContentPage
    {
        ProductDetailViewModel productDetailViewModel;
        public ProductDetailView()
        {
            InitializeComponent();

        }

        public ProductDetailView(Items product)
        {
            InitializeComponent();
            productDetailViewModel = new ProductDetailViewModel(product);
            this.BindingContext = productDetailViewModel;
        }

        void OnAcceptClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var id = btn.ClassId;

            if (id.Equals('1'))
            {

            }
        }


    }
}
