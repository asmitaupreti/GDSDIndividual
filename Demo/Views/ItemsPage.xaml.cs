using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Demo.Models;
using Demo.Views;
using Demo.ViewModels;

namespace Demo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        ControlTemplate template1 = new ControlTemplate(typeof(ProductMenu));
        ControlTemplate template2 = new ControlTemplate(typeof(BarChart));

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            body.ControlTemplate = template1;
            


        }

        private void MenuClicked(object sender, EventArgs e)
        {
            body.ControlTemplate = template1;

        }

        private void BarClicked(object sender, EventArgs e)
        {
            body.ControlTemplate = template2;
        }


    }
}