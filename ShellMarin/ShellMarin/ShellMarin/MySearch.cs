using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ShellMarin
{
    public class MySearch : SearchHandler
    {
        public IList<string> Data { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrEmpty(newValue))
                ItemsSource = null;
            else
            {
                ItemsSource = Data
                    .Where(query => query.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
        }
    }
}
