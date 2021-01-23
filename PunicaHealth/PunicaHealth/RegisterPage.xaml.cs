using PunicaHealth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        void passwordEye(object sender, EventArgs e)
        {
            if (passwordEntry.IsPassword)
            {
                passwordImg.Source = "password.png";
                passwordEntry.IsPassword = false;
            }
            else
            {
                passwordImg.Source = "password_hide.png";
                passwordEntry.IsPassword = true;
            }
        }
    }
}