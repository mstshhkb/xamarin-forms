using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_ListViewSample.Models
{
    public class RamenItem
    {
        public string Main { get; }
        public string Sub { get; }
        public string Image { get; }

        public RamenItem(string main, string sub, string image)
        {
            this.Main = main;
            this.Sub = sub;
            this.Image = image;
        }
    }
}
