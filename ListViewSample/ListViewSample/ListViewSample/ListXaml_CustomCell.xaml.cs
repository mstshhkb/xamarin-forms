using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ListViewSample
{
    public partial class ListXaml_CustomCell : ContentPage
    {
        public ListXaml_CustomCell()
        {
            InitializeComponent();

            const string url = "http://xamarin.com/images/index/ide-xamarin-studio.png";

            var person = new List<Person>
            {
                new Person { Name = "Taro", Age = 18, Url = url },
                new Person { Name = "Jiro", Age = 15, Url = url },
                new Person { Name = "Saburo", Age = 12, Url = url },
                new Person { Name = "Shiro", Age = 10, Url = url },
            };

            this.BindingContext = person;
        }
    }
}
