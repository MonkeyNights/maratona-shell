namespace ShellMarin
{
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Olá", "Maratona Xamarin", "Ok");
        }
    }
}