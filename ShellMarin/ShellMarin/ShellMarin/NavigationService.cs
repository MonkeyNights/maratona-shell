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

        bool isNavigationAllowed;

        Shell Shell => Shell.Current;

        Page CurrentPage => Shell.CurrentPage;

        public static Dictionary<string, Func<Task<bool>>> InterceptNavigationActions { get; } =
            new Dictionary<string, Func<Task<bool>>>();

        NavigationService()
        {
            Shell.Navigated += OnNavigated;
           // Shell.Navigating += OnNavigating;

            RegisterRoute();

            static void RegisterRoute()
            {
                Routing.RegisterRoute(nameof(Page2ViewModel), typeof(Page2));
                Routing.RegisterRoute(nameof(MainViewModel), typeof(MainPage));
                Routing.RegisterRoute(nameof(Page1ViewModel), typeof(Page1));
            }
        }

        //async void OnNavigating(object sender, ShellNavigatingEventArgs e)
        //{
        //    var key = (CurrentPage.BindingContext as BaseViewModel).Key;

        //    InterceptNavigationActions.TryGetValue(key, out var task);

        //    if (task is { }) // task != null
        //    {
        //        var deferral = e.GetDeferral();

        //        var result = await task();

        //        if (!result)
        //            e.Cancel();

        //        deferral.Complete();

        //    }

        //    isNavigationAllowed = !e.Cancelled;
        //}

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
            var currentUri = e.Current.Location.OriginalString;
        }

        public async Task GoToAsync(string uri, params object[] args)
        {
            await Shell.GoToAsync(uri);

            if (uri.Contains(".."))
            {
                await (CurrentPage.BindingContext as BaseViewModel).BackAsync(args).ConfigureAwait(false);
                return;
            }

            await StartVM(uri, args).ConfigureAwait(false);
        }

        ValueTask StartVM(in string uri, object[] args)
        {
            if (!isNavigationAllowed)
                return default;

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
