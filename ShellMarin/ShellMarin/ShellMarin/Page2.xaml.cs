using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShellMarin
{
    public partial class Page2
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("..");
        }
    }


    sealed class Page2ViewModel : BaseViewModel
    {
        public Page2ViewModel()
        {
            NavigateCommand = new Command(NavigateCommandExecute);
        }

        void NavigateCommandExecute()
        {
            var item = new Item
            {
                Id = 20,
                Name = "Maratona Shell"
            };

            var args = new Dictionary<int, object>
            {
                {0 , item },
                {1 ,  "Monkey Nights"}
            };


            _ = Navigation.GoToAsync("..", args);
        }
    }
}