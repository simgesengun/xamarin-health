﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PunicaHealth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public MDPMaster()
        {
            InitializeComponent();
        }
        async void LogoutClicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }
    }
}