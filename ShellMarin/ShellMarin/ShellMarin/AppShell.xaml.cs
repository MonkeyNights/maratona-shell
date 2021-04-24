using System.Collections.Generic;
using Xamarin.Forms;

namespace ShellMarin
{
    public partial class AppShell
    {
        public static List<string> DataBase = new List<string>
        {
            "Língua de boi",
            "Sopa de Ninhos de andorinha",
            "Escorpião no espeto",
            "Pizza de sorvete",
            "Escargot",
            "Tartufo bianco",
            "Sarapatéu",
            "Churrisco",
            "Mondongo",
            "Queijo Caso Marcio",
            "Ovo secolar"
        };

        public AppShell()
        {
            InitializeComponent();

            //var x = new MySearch
            //{
            //    SearchBoxVisibility = SearchBoxVisibility.Collapsible
            //}
        }
    }
}