using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Demo.Models
{
    public class AdminMessage : ObservableObject
    {
        private int _sender;

        [JsonProperty(PropertyName = "sender")]
        public int sender
        {
            get { return _sender; }
            set { SetProperty(ref _sender, value); }
        }

        private string _name;

        [JsonProperty(PropertyName = "name")]
        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }

        }

        private string _content;

        [JsonProperty(PropertyName = "content")]
        public string content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }

        }

        private int _productId;

        [JsonProperty(PropertyName = "productId")]
        public int productId
        {
            get { return productId; }
            set { SetProperty(ref _productId, value); }
        }


    }
}