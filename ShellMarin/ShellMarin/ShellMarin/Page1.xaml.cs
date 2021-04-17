using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellMarin
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
    }

    sealed class Page1ViewModel : BaseViewModel
    {

        string maratona;

        public string Maratona
        {
            get => maratona;
            set => SetProperty(ref maratona, value);
        }


        public override Task InitAsync(object[] args = null)
        {
            var value = (string)args[0];
            var item = (Item)args[1];
            Debug.WriteLine(item);
            Maratona = value;
            return base.InitAsync(args);
        }
    }
}