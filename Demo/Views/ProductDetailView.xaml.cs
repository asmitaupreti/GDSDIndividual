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
        StatusUpdateModel s = new StatusUpdateModel();
        public ProductDetailView()
        {
            InitializeComponent();

        }

        public ProductDetailView(Items product , AcceptRejectDesign a)
        {
            InitializeComponent();
            productDetailViewModel = new ProductDetailViewModel(product,a);
            this.BindingContext = productDetailViewModel;
        }

        void OnAcceptClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            
            s.id = productDetailViewModel.Product.Id;
            s.status = "approved";
            productDetailViewModel.AcceptPressedCommand.Execute(s);  
        }

        void OnRejectClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var id = btn.ClassId;
            s.id = productDetailViewModel.Product.Id;
            s.status = "unapproved";
            productDetailViewModel.RejectPressedCommand.Execute(s);
        }

    }
}
