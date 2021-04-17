﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellMarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(Page2)}");
        }
    }


    sealed class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            NavigateCommand = new Command(NavigateCommandExecute);
        }

        void NavigateCommandExecute()
        {
            _ = Navigation.GoToAsync(nameof(Page2ViewModel));
        }
    }
}
