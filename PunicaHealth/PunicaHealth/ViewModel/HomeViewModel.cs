using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PunicaHealth.ViewModel
{

    public static class HomeViewModel
    {
        public static ObservableCollection<ListItem> specialists { get; set; }

        static HomeViewModel()
        {
        }

    }
}
