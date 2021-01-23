using PunicaHealth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string popupUsers;
        public LoginPage()
        {
            InitializeComponent();
            // uncomment below line to see existing users 
            //getUsers();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());

        }
        async void getUsers()
        {
            List<User> users= await App.Database.GetUserAsync();
            foreach (User user in users) {
                popupUsers += "ID = " + user.Id + "\nEmail = " + user.email + "\nPassword = " + user.password+"\n";
            }
            await DisplayAlert("Users", popupUsers, "OK");

        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            bool exists = await App.Database.userExistsAsync(emailEntry.Text, passwordEntry.Text);
            passwordEntry.Text = string.Empty;
            if (exists)
            {
                emailEntry.Text = string.Empty;
                await Navigation.PushModalAsync(new MDPDetail());
            }
            else {
                if (await DisplayAlert("Invalid email or password", "Would you like to register?", "Sign Up", "Try Again")) {
                    emailEntry.Text = string.Empty;
                    await Navigation.PushAsync(new RegisterPage());
                }
            }

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
        void emailCheck(object sender, EventArgs e)
        {
            if (IsValid(emailEntry.Text))
                emailImg.Source = "check_filled.png";
            else
                emailImg.Source = "check.png";
        }
        public bool IsValid(string emailaddress)
        {
            return Regex.IsMatch(emailaddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}