using System;
using MvvmHelpers;

namespace Demo.Models
{
    public class Images : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }

        }

    }
}
