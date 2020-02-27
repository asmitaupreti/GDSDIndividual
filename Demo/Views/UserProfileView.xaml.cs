using System;
using System.Collections.Generic;
using Demo.ViewModels;
using Xamarin.Forms;

namespace Demo.Views
{
    public partial class UserProfileView : ContentPage
    {
        ProfileViewModel vm = new ProfileViewModel();
        public UserProfileView()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        void Entry_TextChanged(object sender, EventArgs e)
        {
            var entryField = sender as Entry;
            var newText = entryField.Text;
           /* this.vm.ConfirmPasswordCommand.Execute(newText);*/
        }

        private void onSaveClicked(object sender, EventArgs e)
        {
            vm.validateNameCommand.Execute(null);
            vm.validatePasswordCommand.Execute(null);
            vm.UpdateProfileDataCommand.Execute(null);
        }
    }
}
