using System;
using System.Collections.Generic;
using System.Text;

namespace ShellMarin
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GUID { get; set; } = Guid.NewGuid().ToString();


        public override string ToString() => $"{Id} {Name} {GUID}";
    }
}
