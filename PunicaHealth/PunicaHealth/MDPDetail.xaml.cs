using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPDetail : MasterDetailPage
    {
        public MDPDetail()
        {

            InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
            MDPMaster.listView.ItemSelected += OnItemSelected;

        }
    

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item != null)
            {
                Page displayPage = (Page)Activator.CreateInstance(item.TargetType);
                Detail.Navigation.PushAsync(displayPage);
                MDPMaster.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}