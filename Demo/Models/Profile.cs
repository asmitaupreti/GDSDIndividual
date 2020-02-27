using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Profile : ObservableObject
    {
        private int id;

        [JsonProperty(PropertyName = "Id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string _name;

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }

        }

        private string _password;

        [JsonProperty(PropertyName = "password")]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }

        }

    }
}