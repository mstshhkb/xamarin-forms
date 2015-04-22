using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XF_JsonReader
{
    public class DetailPage : ContentPage
    {
        public DetailPage(Root.Article article)
        {
            // コントロールを定義します
            var image = new Image
            {
                Source = article.image_url,
                VerticalOptions = LayoutOptions.Start
            };
            var title = new Label
            {
                Text = article.title,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            var day = new Label
            {
                Text = article.published_date.ToString("yyyy/M/d h:mm"),
                TextColor = Color.FromHex("#3498DB"),
            };
            var context = new ScrollView
            {
                Content = new Label
                {
                    Text = article.context,
                    FontSize = 15,
                },
            };

            // 2x3 の Grid を用意します
            var grid = new Grid
            {
                Padding = 5,
                RowSpacing = 7,
                ColumnSpacing = 7,
                RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = new ColumnDefinitionCollection {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
            };

            // Grid に Children を追加します
            grid.Children.Add(image, 0, 1, 0, 2);
            grid.Children.Add(title, 1, 2, 0, 1);
            grid.Children.Add(day, 1, 2, 1, 2);
            grid.Children.Add(context, 1, 2, 2, 3);

            Title = article.title;
            Content = grid;
        }
    }
}
