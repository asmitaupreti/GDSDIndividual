using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class UserModel : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }



        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }

        }

        private int status;
        public int Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
    }
}