using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using FluentValidation.Results;
using PunicaHealth.Data;
using Xamarin.Forms;

namespace PunicaHealth.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string errorMessage, success;
        public RegisterViewModel() {
        }
        private bool _isValid;

        public bool isValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("isValid"));


            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                if (Regex.IsMatch(Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string _dob;
        public string Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dob"));
            }
        }
        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weight"));
            }
        }
        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                _height = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Height"));
            }
        }
        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        async private void Register()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Dob)
                || string.IsNullOrWhiteSpace(Weight) || string.IsNullOrWhiteSpace(Height))
            {
                await App.Current.MainPage.DisplayAlert("Register", "Please fill all entries", "OK");
            }
            else
            {
                if (await Validate())
                {
                    await App.Database.SaveUserAsync(new User
                    {
                        email = Email,
                        password = Password,
                        dob = Dob,
                        weight = int.Parse(Weight),
                        height = int.Parse(Height),
                    });
                    success = "You have registered successfully!";
                    //uncomment below line to see more info about this user
                    //success += "\nEmail: " + Email + "\nPassword: " + Password + "\nDOB: " + Dob + "\nWeight: " + Weight + "\nHeight: " + Height + "\n";
                    await App.Current.MainPage.DisplayAlert("Register", success, "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Register", errorMessage, "OK");
                }
            }
                
        }
        public bool checkInt(string entry)
        {
            try
            {
                int.Parse(entry);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> validateEmail()
        {
            if (isValid)
            {
                bool available = await App.Database.emailAvailableAsync(Email);
                if (available)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Email is already registered";
                    return false;
                }
            }
            else
            {
                errorMessage = "Please enter a valid email";
                return false;
            }

        }
        public bool validatePassword()
        {
            return true;
        }
        public bool validateDob()
        {
            if (Regex.IsMatch(Dob, @"\d{2}\/\d{2}\/\d{4}")) { return true; }
            else
            {
                errorMessage = "Please enter a valid date of birth";
                return false;
            }
        }
        public bool validateHeight()
        {
            if (checkInt(Height)) { return true; }
            else
            {
                errorMessage = "Please enter a valid height";
                return false;
            }
        }
        public bool validateWeight()
        {
            if (checkInt(Weight)) { return true; }
            else {
                errorMessage = "Please enter a valid weight";
                return false; 
            }
        }
        public async Task<bool> Validate()
        {
            bool weight = validateWeight();
            bool height = validateHeight();
            bool dob = validateDob();
            bool password = validatePassword();
            bool email = await validateEmail();
            return email && password && dob && height && weight;
        }
        
    }
}
