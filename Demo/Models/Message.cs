using System;
using MvvmHelpers;
using Newtonsoft.Json;

namespace Demo.Models
{
    public class Message : ObservableObject
    {

        private int _User;

        [JsonProperty(PropertyName = "User")]
        public int User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }

        private string _Text;

        [JsonProperty(PropertyName = "Text")]
        public string Text
        {
            get { return _Text; }
            set { SetProperty(ref _Text, value); }

        }

       


    }

}
