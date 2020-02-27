using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class ReceiveMessage : ObservableObject
    {

        private int sender_id;

        [JsonProperty(PropertyName = "senderId")]
        public int senderId
        {
            get { return sender_id; }
            set { SetProperty(ref sender_id, value); }
        }

        private int product_id;

        [JsonProperty(PropertyName = "productId")]
        public int productId
        {
            get { return product_id; }
            set { SetProperty(ref product_id, value); }
        }

        private int receiver_id;

        [JsonProperty(PropertyName = "receiverId")]
        public int receiverId
        {
            get { return receiver_id; }
            set { SetProperty(ref receiver_id, value); }
        }
    }
}