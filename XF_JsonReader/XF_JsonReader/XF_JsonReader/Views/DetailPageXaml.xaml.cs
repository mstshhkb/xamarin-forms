using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XF_JsonReader.Models;

namespace XF_JsonReader.Views
{
    public partial class DetailPageXaml : ContentPage
    {
        public DetailPageXaml(RootObject.Post post)
        {
            InitializeComponent();

            this.BindingContext = post;
        }

        public void Label_Clicked(object sender, EventArgs e)
        {
            var url = ((Label)sender).Text;
            Device.OpenUri(new Uri(url));
        }
    }
}
