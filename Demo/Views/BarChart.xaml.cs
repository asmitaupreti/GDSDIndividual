using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarChart : ContentView
    {
        ItemsViewModel viewModel;
        public BarChart()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            viewModel.LoadBarChartDataCommand.Execute(null);
        }
    }
}