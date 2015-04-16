using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ListViewSample
{
    public partial class ListXaml_TextCell : ContentPage
    {
        public ListXaml_TextCell()
        {
            InitializeComponent();

            // BindingContext が List の場合は <ListView.ItemTemplate> が必要です。
            var person = new List<Person>
            {
                new Person { Name = "Taro", Age = 18 },
                new Person { Name = "Jiro", Age = 15 },
                new Person { Name = "Saburo", Age = 12 },
                new Person { Name = "Shiro", Age = 10 },
            };

            // 何を Binding するか指定します。
            this.BindingContext = person;
        }
    }
}
