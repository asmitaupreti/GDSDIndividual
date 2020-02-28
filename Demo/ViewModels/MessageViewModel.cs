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
   public class MessageViewModel : ObservableObject
    {

        private AdminMessage selection;

        public AdminMessage Selection
        {
            get { return selection; }
            set { SetProperty(ref selection, value); }
        }

        private ObservableCollection<AdminMessage> itemsCollection;
        public ObservableCollection<AdminMessage> ItemsCollection
        {

            get
            {
                if (itemsCollection == null) ItemsCollection = new ObservableCollection<AdminMessage>();
                return itemsCollection;
            }


            set
            {
                SetProperty(ref itemsCollection, value);

            }
        }

        private ObservableCollection<AdminMessage> removeItem;
        public ObservableCollection<AdminMessage> RemoveItem
        {

            get
            {
                if (removeItem == null) RemoveItem = new ObservableCollection<AdminMessage>();
                return removeItem;
            }


            set
            {
                SetProperty(ref removeItem, value);

            }
        }

        private ObservableCollection<AdminMessage> displayItemsCollection;
        public ObservableCollection<AdminMessage> DisplayItemsCollection
        {

            get
            {
                if (displayItemsCollection == null) DisplayItemsCollection = new ObservableCollection<AdminMessage>();
                return displayItemsCollection;
            }


            set
            {
                SetProperty(ref displayItemsCollection, value);

            }
        }

        public Command LoadUserDataCommand { get; set; }

        private Command _refreshViewCommand;
        public Command RefreshViewCommand
        {
            get
            {
                return _refreshViewCommand ?? (_refreshViewCommand = new Command(async async =>
                {
                    await TotalUserDataCommand();
                }));
            }
        }

        public MessageViewModel()
        {
            LoadUserDataCommand = new Command(async async => await TotalUserDataCommand());
            LoadUserDataCommand.Execute(null);
            createMessageList();

        }

        async System.Threading.Tasks.Task TotalUserDataCommand()
        {
            ItemsCollection = await APIServices.GetMessageData(Constants.messageEndpoint,21);
            /*createMessageList();*/


        }

        public  void createMessageList()
        {
            

            foreach (var item in  ItemsCollection)
            {
                Console.WriteLine(item.sender);
                Console.WriteLine(item.productId);

                /*if (DisplayItemsCollection.Count == 0)
                {

                    DisplayItemsCollection.Add(item);
                    Console.WriteLine(item.productId);
                    Console.WriteLine(item.sender);

                }*/
                /*else if (DisplayItemsCollection.Any(p => (p.sender == item.sender) && (p.productId == item.productId)) == false)
                {
                    DisplayItemsCollection.Add(item);
                    
                }
                else
                {
                    RemoveItem.Add(item);
                }*/
            }
        }

    }

}
