using System;
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

        bool canNavigate;

        public bool CanNavigate
        {
            get => canNavigate;
            set => SetProperty(ref canNavigate, value);
        }

        public MainViewModel()
        {
            NavigateCommand = new Command(NavigateCommandExecute);

            //NavigationService.InterceptNavigationActions[Key] = async () =>
            //{
            //    var result = await Application.Current.MainPage.DisplayAlert("Aviso",
            //        "Quer navegar assim mesmo?", "Sim", "Não");

            //    return result;
            //};
        }

        void NavigateCommandExecute()
        {
            _ = Navigation.GoToAsync(nameof(Page2ViewModel));
        }

        public override Task BackAsync(params object[] args)
        {
            var dic = (Dictionary<int, object>)args[0];

            dic.TryGetValue(0, out var item1);
            
            return base.BackAsync(args);
        }
    }
}
