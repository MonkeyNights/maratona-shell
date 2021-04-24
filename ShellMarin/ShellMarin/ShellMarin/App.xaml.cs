using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellMarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            _ = NavigationService.Current;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
