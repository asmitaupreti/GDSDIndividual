using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Demo.Models;
using Xamarin.Forms;

namespace Demo.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<Message> DelayedMessages { get; set; } = new Queue<Message>();
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel()
        {
            Messages.Insert(0, new Message() { Text = "Hi", User = 2 });
            Messages.Insert(0, new Message() { Text = "How are you?", User = 1 });
            Messages.Insert(0, new Message() { Text = "What's new?", User = 2 });
            Messages.Insert(0, new Message() { Text = "How is your family", User = 1 });
            Messages.Insert(0, new Message() { Text = "How is your dog?", User = 1 });
            Messages.Insert(0, new Message() { Text = "How is your cat?", User = 1 });
            Messages.Insert(0, new Message() { Text = "How is your sister?", User = 2 });
            Messages.Insert(0, new Message() { Text = "When we are going to meet?", User = 2 });
            Messages.Insert(0, new Message() { Text = "I want to buy a laptop", User = 2 });
            Messages.Insert(0, new Message() { Text = "Where I can find a good one?", User = 2 });
            Messages.Insert(0, new Message() { Text = "Also I'm testing this chat", User = 2 });
            Messages.Insert(0, new Message() { Text = "Oh My God!", User = 2 });
            Messages.Insert(0, new Message() { Text = " No Problem", User = 1 });
            Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = 1 });
            Messages.Insert(0, new Message() { Text = "When we are going to meet?", User = 2 });
            Messages.Insert(0, new Message() { Text = "I want to buy a laptop", User = 2 });
            Messages.Insert(0, new Message() { Text = "Where I can find a good one?", User = 2 });
            Messages.Insert(0, new Message() { Text = "Also I'm testing this chat", User = 2 });
            Messages.Insert(0, new Message() { Text = "Oh My God!", User = 2 });
            Messages.Insert(0, new Message() { Text = " No Problem", User = 2 });
            Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = 2 });

            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Insert(0, new Message() { Text = TextToSend, User = 1 });
                    TextToSend = string.Empty;
                }

            });

            //Code to simulate reveing a new message procces
           /* Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (LastMessageVisible)
                {
                    Messages.Insert(0, new Message() { Text = "New message test", User = 2 });
                }
                else
                {
                    DelayedMessages.Enqueue(new Message() { Text = "New message test", User = 2 });
                    PendingMessageCount++;
                }
                return true;
            });*/



        }

        void OnMessageAppearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
