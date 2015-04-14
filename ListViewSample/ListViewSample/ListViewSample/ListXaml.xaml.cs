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

            // BindingContext が List の場合は <ListView.ItemTemplate> が必要
            var person = new List<Person>
            {
                new Person { Name = "Taro", Age = 18 },
                new Person { Name = "Jiro", Age = 15 },
                new Person { Name = "Saburo", Age = 12 }
            };

            // BindingContext が配列の場合は、ItemTemplate 不要
            //var person = new string[] { "Taro", "Jiro", "Saburo" };

            // 何を Binding するか (<ListView ItemsSource="{Binding person}"> だと表示できないのは要勉強…)
            this.BindingContext = person;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // 行選択を解除
        }
    }
}
