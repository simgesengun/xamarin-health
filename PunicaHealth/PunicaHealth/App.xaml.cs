using Newtonsoft.Json;
using PunicaHealth.Data;
using PunicaHealth.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return database;
            }
        }
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental" });
            InitializeComponent();
            Sharpnado.Tabs.Initializer.Initialize(loggerEnable: false, debugLogEnable:false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            var nav = new NavigationPage(new LoginPage());
            nav.BarBackgroundColor = Color.White;
            nav.BackgroundColor = Color.White;
            MainPage = nav;

        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey("specialists"))
            {
                var json = Application.Current.Properties["specialists"] as string;
                HomeViewModel.specialists = JsonConvert.DeserializeObject<ObservableCollection<ListItem>>(json);
                
            }
            else
            {
                HomeViewModel.specialists = new ObservableCollection<ListItem>();
                HomeViewModel.specialists.Add(new ListItem() { Img = "doc_Tia_Wells.jpg", Type = "Otolaryngologist", Name = "Tia Wells", Detail = "stars_5.png", Button = "BOOK" });

            }
        }

        async protected override void OnSleep()
        {
            var jsonValueToSave = JsonConvert.SerializeObject(HomeViewModel.specialists);
            Application.Current.Properties["specialists"] = jsonValueToSave;
            await Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
