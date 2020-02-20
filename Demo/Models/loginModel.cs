using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class loginModel : ObservableObject
    {
        private int id;

        [JsonProperty(PropertyName = "Id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string _email;

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }

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
