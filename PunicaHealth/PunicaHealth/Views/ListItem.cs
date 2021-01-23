using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PunicaHealth
{
    public class ListItem
    {
        public string Img { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Button { get; set; }
        public ListItem() { }
        public ListItem(string img, string type, string name, string detail, string button)
        {
            this.Img = img;
            this.Type = type;
            this.Name = name;
            this.Detail = detail;
            this.Button = button;
        }
    }
}
