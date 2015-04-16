using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ListViewSample
{
    public partial class ListXaml : ContentPage
    {
        public ListXaml()
        {
            InitializeComponent();

            // BindingContext が配列の場合は、ItemTemplate 不要です。
            var person = new string[] { "Taro", "Jiro", "Saburo", "Shiro" };

            // 何を Binding するか指定します。
            this.BindingContext = person;
        }
    }
}
