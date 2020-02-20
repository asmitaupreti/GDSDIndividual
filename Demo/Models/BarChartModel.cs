using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class BarChartModel : ObservableObject
    {
        public BarChartModel()
        {
        }
        int Id;
        string categoryname;
        int totalproduct;



        public int id
        {
            get { return Id; }
            set { SetProperty(ref Id, value); }
        }

        public string categoryName
        {
            get { return categoryname; }
            set { SetProperty(ref categoryname, value); }
        }

        public int totalProduct
        {
            get { return totalproduct; }
            set { SetProperty(ref totalproduct, value); }
        }




    }

}
