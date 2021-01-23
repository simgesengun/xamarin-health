using PunicaHealth.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Specialists : ContentPage
    {
        public ObservableCollection<ListItem> allSpecialists = new ObservableCollection<ListItem>();

        public Specialists()
        {
            InitializeComponent();
            listView.ItemsSource = allSpecialists;
            allSpecialists.Add(new ListItem() { Img = "doc_Tia_Wells.jpg", Type = "Otolaryngologist", Name = "Tia Wells", Detail = "stars_5.png", Button = "BOOK" });
            allSpecialists.Add(new ListItem() { Img = "doc_Rea_Galloway.jpg", Type = "Psychiatrist", Name = "Rea Galloway", Detail = "stars_4.png", Button = "BOOK" });
            allSpecialists.Add(new ListItem() { Img = "doc_Jordon_Adam.jpeg", Type = "Gynecologist", Name = "Jordon Adam", Detail = "stars_5.png", Button = "BOOK" });
            allSpecialists.Add(new ListItem() { Img = "doc_Avneet_Dougherty.jpeg", Type = "Cardiologist", Name = "Avneet Dougherty", Detail = "stars_3.png", Button = "BOOK" });
            allSpecialists.Add(new ListItem() { Img = "doc_Camilla_Glover.jpeg", Type = "Neurologist", Name = "Camilla Glover", Detail = "stars_2.png", Button = "BOOK" });

        }
        public void buttonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (ListItem)button.BindingContext;
            HomeViewModel.specialists.Add(item);

        }
    }
}