using Demo.Models;
using Demo.ViewModels;
using Syncfusion.ListView.XForms;
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
    public partial class MessageView : ContentPage
    {
        MessageViewModel vm;
        public MessageView()
        {
            InitializeComponent();
            this.BindingContext = vm = new MessageViewModel();
        }

        private void ListView_OnSelectionChanged(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
           var selection = e.ItemData as AdminMessage;
            Console.WriteLine(selection);
        }
    }
}