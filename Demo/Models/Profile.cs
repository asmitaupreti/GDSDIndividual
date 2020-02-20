using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Profile : ObservableObject
    {
        public Profile()
        {
        }
        int id;
        string username;
        string email;
        bool password;


        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public bool Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


    }

}