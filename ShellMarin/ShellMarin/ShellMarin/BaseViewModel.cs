using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellMarin
{
    abstract class BaseViewModel : INotifyPropertyChanged
	{
		protected Shell CurrentShell => Shell.Current;

		public string Key { get; } = Guid.NewGuid().ToString();

		protected NavigationService Navigation => NavigationService.Current;

		bool isBusy = false;
		public bool IsBusy
		{
			get => isBusy;
			set => SetProperty(ref isBusy, value);
		}

		string title = string.Empty;
		public string Title
		{
			get => title;
			set => SetProperty(ref title, value);
		}

		public Command NavigateCommand { get; protected set; }

		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public virtual Task InitAsync(params object[] args) => Task.CompletedTask;

		public virtual Task BackAsync(params object[] args) => Task.CompletedTask;


		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;

			changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
