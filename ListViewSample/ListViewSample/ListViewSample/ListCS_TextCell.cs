using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class ListCS_TextCell : ContentPage
    {
        public ListCS_TextCell()
        {
            // TextCell: TextProperty と DetailProperty を Binding します
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding("Age", stringFormat: "{0}才"));

            // ItemTemplate に TextCell を指定します
            var list = new ListView
            {
                ItemsSource = new List<Person>
                {
                    new Person { Name = "Taro", Age = 18 },
                    new Person { Name = "Jiro", Age = 15 },
                    new Person { Name = "Saburo", Age = 12 },
                    new Person { Name = "Shiro", Age = 10 },
                },
                ItemTemplate = cell,
            };

            Title = "List<T>でTextCellのListView";
            Content = list;
        }
    }
}
