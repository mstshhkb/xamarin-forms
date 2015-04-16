using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class ListCS_ImageCell : ContentPage
    {
        public ListCS_ImageCell()
        {
            const string url = "http://xamarin.com/images/index/ide-xamarin-studio.png";

            // ImageCell: ImageSourceProperty, TextProperty, DetailProperty を Binding します
            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(ImageCell.ImageSourceProperty, "Url");
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding("Age", stringFormat: "{0}才"));

            var list = new ListView
            {
                ItemsSource = new List<Person>
                {
                    new Person { Name = "Taro", Age = 18, Url = url },
                    new Person { Name = "Jiro", Age = 15, Url = url },
                    new Person { Name = "Saburo", Age = 12, Url = url },
                    new Person { Name = "Shiro", Age = 10, Url = url },
                },
                ItemTemplate = cell,
            };

            Title = "List<T>でImageCellのListView";
            Content = list;
        }
    }
}
