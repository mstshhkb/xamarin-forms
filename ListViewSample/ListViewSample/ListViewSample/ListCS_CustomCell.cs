using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class ListCS_CustomCell : ContentPage
    {
        public ListCS_CustomCell()
        {
            const string url = "http://xamarin.com/images/index/ide-xamarin-studio.png";

            // CustomCell: レイアウトを ViewCell を継承したクラスで自由に定義します
            var list = new ListView
            {
                ItemsSource = new List<Person>
                {
                    new Person { Name = "Taro", Age = 18, Url = url },
                    new Person { Name = "Jiro", Age = 15, Url = url },
                    new Person { Name = "Saburo", Age = 12, Url = url },
                    new Person { Name = "Shiro", Age = 10, Url = url },
                },
                ItemTemplate = new DataTemplate(typeof(cell)),
            };

            Title = "List<T>でCustomCellのListView";
            Content = list;
        }
    }

    /// <summary>
    /// ViewCell を継承した Custom DataTemplate
    /// </summary>
    public class cell : ViewCell
    {
        public cell()
        {
            // Name
            var nameLabel = new Label { Style = Device.Styles.TitleStyle };
            nameLabel.SetBinding(Label.TextProperty, "Name");
            // Age
            var ageLabel = new Label { TextColor = Color.Navy, VerticalOptions = LayoutOptions.Center };
            ageLabel.SetBinding(Label.TextProperty, new Binding("Age", stringFormat: "{0}才"));

            // Image
            var image = new Image { HorizontalOptions = LayoutOptions.EndAndExpand, };
            image.SetBinding(Image.SourceProperty, "Url");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
                Children =
                    {
                        nameLabel,
                        ageLabel,
                        image,
                    },
            };
        }
    }


}
