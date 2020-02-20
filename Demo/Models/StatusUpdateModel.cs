using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class StatusUpdateModel : ObservableObject
    {
        private string _status;

        [JsonProperty(PropertyName = "status")]
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }

        }

    }
}