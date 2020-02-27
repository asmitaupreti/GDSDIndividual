using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static Demo.Constant.Constant;

namespace Demo.ViewModels
{
   public class MessageDetailViewModel : ObservableObject
    {

        private ObservableCollection<Message> messageCollection;

        public ObservableCollection<Message> MessageCollection
        {

            get
            {
                if (messageCollection == null) MessageCollection = new ObservableCollection<Message>();
                return messageCollection;
            }


            set
            {
                SetProperty(ref messageCollection, value);

            }
        }

        private AdminMessage _message;

        public AdminMessage Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
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
                SetProperty(ref isLoading, value);
            }
        }


        private string outgoingText;

        public string OutGoingText
        {
            get { return outgoingText; }
            set
            {
                SetProperty(ref outgoingText, value);
            }
        }
        public Command LoadMessageDataCommand { get; set; }


        public MessageDetailViewModel(AdminMessage a)
        {
            IsLoading = true;

            this.Message = a;

            LoadMessageDataCommand = new Command(async async => await TotalMessageDataCommand());
            LoadMessageDataCommand.Execute(null);


        }

        async System.Threading.Tasks.Task TotalMessageDataCommand()
        {
            int id = Int32.Parse(Application.Current.Properties["id"].ToString());

            MessageCollection = await APIServices.GetSpecificMessageData(Constants.specificMessageEndpoint, Message.sender,Message.productId,id);

            IsLoading = false;

        }
    }
}