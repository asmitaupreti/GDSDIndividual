using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage(AdminMessage a)
        {
            InitializeComponent();
           this.BindingContext = new MessageDetailViewModel(a);
        }

       
    }
}