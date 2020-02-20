using System;
using System.Collections.ObjectModel;
using MvvmHelpers;
using Xamarin.Forms;

namespace Demo.Models
{
    public class Items :ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }

        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }

        }

        private int totalnumber;
        public int totalNumber
        {
            get { return totalnumber; }
            set { SetProperty(ref totalnumber, value); }

        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }

        }

        private ObservableCollection<Images> imageCollection;
        public ObservableCollection<Images> ImageCollection
        {
            get
            {
                if (imageCollection == null) ImageCollection = new ObservableCollection<Images>();
                return imageCollection;
            }
            set { SetProperty(ref imageCollection, value); }
        }

        /*public Items (int id, string text, string description)
        {
            Id = id;
            Text = text;
            Description = description;
        }*/
    }
}