using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellMarin
{
    internal sealed class NavigationService
    {
        static Lazy<NavigationService> navigationLazy =
            new Lazy<NavigationService>(() => new NavigationService());

        public static NavigationService Current => navigationLazy.Value;

        Shell Shell => Shell.Current;

        Page CurrentPage => Shell.CurrentPage;

        NavigationService()
        {
            Shell.Navigated += OnNavigated;
            Shell.Navigating += OnNavigating;

            RegisterRoute();

            void RegisterRoute()
            {
                Routing.RegisterRoute(nameof(Page2ViewModel), typeof(Page2));
                Routing.RegisterRoute(nameof(MainViewModel), typeof(MainPage));
                Routing.RegisterRoute(nameof(Page1ViewModel), typeof(Page1));
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {

        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
         
        }

        public async Task GoToAsync(string uri, params object[] args)
        {
            await Shell.GoToAsync(uri);

            await StartVM(uri, args).ConfigureAwait(false);
        }

        ValueTask StartVM(in string uri, object[] args)
        {
            var vm = CreateViewModel(uri);

            CurrentPage.BindingContext = vm;

            return new ValueTask(vm.InitAsync(args));
        }

        BaseViewModel CreateViewModel(in string uri)
        {
            var type = $"ShellMarin.{uri}";
            var viewModel = (BaseViewModel)Activator.CreateInstance(Type.GetType(type));
            return viewModel;
        }
    }
}
