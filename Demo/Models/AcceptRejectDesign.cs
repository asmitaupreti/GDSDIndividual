using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class AcceptRejectDesign : ObservableObject
    {
        private bool stackVisible;

        public bool StackVisible
        {
            get
            {
                return stackVisible;
            }

            set
            {
                SetProperty(ref stackVisible, value); ;
            }
        }

        private bool acceptVisible;

        public bool AcceptVisible
        {
            get
            {
                return acceptVisible;
            }

            set
            {
                SetProperty(ref acceptVisible, value); ;
            }
        }

        private bool rejectVisible;

        public bool RejectVisible
        {
            get
            {
                return rejectVisible;
            }

            set
            {
                SetProperty(ref rejectVisible, value); ;
            }
        }
    }
}
