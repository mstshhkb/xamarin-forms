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
                new Person { Name = "Taro", Birthday = new DateTime(1997, 1, 1), Url = url },
                new Person { Name = "Jiro", Birthday = new DateTime(2000, 2, 1), Url = url },
                new Person { Name = "Saburo", Birthday = new DateTime(2003, 3, 1), Url = url },
                new Person { Name = "Shiro", Birthday = new DateTime(2005, 4, 1), Url = url },
            };

            this.BindingContext = person;
        }
    }
}
