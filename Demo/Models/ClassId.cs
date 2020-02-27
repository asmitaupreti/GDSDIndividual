using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
   public class ClassId : ObservableObject
    {
        private int _id;

        [JsonProperty(PropertyName = "id")]
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
    }
}