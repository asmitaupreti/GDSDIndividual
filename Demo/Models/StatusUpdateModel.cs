using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class StatusUpdateModel : ObservableObject
    {

        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _status;

        [JsonProperty(PropertyName = "status")]
        public string status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }

        }

    }
}