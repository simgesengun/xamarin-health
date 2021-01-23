using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PunicaHealth.ViewModel;

namespace PunicaHealth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentView
    {
        public ObservableCollection<ListItem> toDo = new ObservableCollection<ListItem>();

        public Home()
        {
            InitializeComponent();
            populateLists();
        }

        public void populateLists()
        {
            toDo.Add(new ListItem() { Img = "list_Brain.png", Type = "Doctors", Name = "Brain Checkout", Detail = "Have an appointment today", Button = "VIEW" });
            toDo.Add(new ListItem() { Img = "list_Prescription.png", Type = "Pharmacy", Name = "Purchase Prescription", Detail = "Don't forget to bring the list with you", Button = "SET" });

            toDoList.ItemsSource = toDo;
        }

        async void ButtonProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(3));

        }
        async void ButtonDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailsPage());
        }

    }
}