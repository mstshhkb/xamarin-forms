using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class ListCS : ContentPage
    {
        public ListCS()
        {
            var list = new ListView
            {
                // ItemSource が List の場合は ItemTemplate に DataTemplate(typeof( が必要
                ItemsSource = new List<Person>
                {
                    new Person { Name = "Taro", Age = 18 },
                    new Person { Name = "Jiro", Age = 15 },
                    new Person { Name = "Saburo", Age = 12 }
                },
                ItemTemplate = new DataTemplate(typeof(PersonCell)),
            };
            list.ItemTapped += List_ItemTapped;

            //var list = new ListView
            //{
            //    // ItemSource が配列の場合は、ItemTemplate 不要
            //    ItemsSource = new string[] { "Taro", "Jiro", "Saburo" }
            //};

            Content = list;
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // 行選択を解除
        }
    }

    // ViewCell の DataTemplate
    public class PersonCell : ViewCell
    {
        public PersonCell()
        {
            // Name 表示用
            var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
            nameLabel.SetBinding(Label.TextProperty, "Name");
            // Age 表示用
            var ageLabel = new Label { TextColor = Color.Navy };
            ageLabel.SetBinding(Label.TextProperty, "Age");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
                Children =
                    {
                        nameLabel,
                        ageLabel
                    },
            };
        }
    }
}
