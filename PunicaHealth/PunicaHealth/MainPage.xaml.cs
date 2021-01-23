using PunicaHealth.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PunicaHealth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TabHost.SelectedIndex = 0;
        }

        public MainPage(int x)
        {
            InitializeComponent();
            TabHost.SelectedIndex = x;
        }
        async void addButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Specialists());

        }
    }
}
