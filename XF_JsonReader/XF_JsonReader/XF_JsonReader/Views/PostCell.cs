using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XF_JsonReader.Views
{
    /// <summary>
    /// ListViewCS で使用する ViewCell です。`ItemTemplate = new DataTemplate(typeof(` で呼び出します。
    /// </summary>
    public class PostCell : ViewCell
    {
        public PostCell()
        {
            var title = new Label
            {
                TextColor = Color.FromHex("22638e"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            title.SetBinding(Label.TextProperty, "title");

            var contents = new Label
            {
                TextColor = Color.FromHex("444"),
            };
            contents.SetBinding(Label.TextProperty,
                new Binding("excerpt", converter: new Converters.HtmlToPlainConverter()));

            var auth = new Label
            {
                TextColor = Color.Gray,
            };
            auth.SetBinding(Label.TextProperty, "author.name", stringFormat: "作成者： {0}");

            var date = new Label
            {
                TextColor = Color.Gray,
            };
            date.SetBinding(Label.TextProperty,
                new Binding("date", stringFormat: "登録日時： {0:yyyy/MM/dd HH:mm}"));

            #region 左側の日付Box

            var hMonth = new Label
            {
                TextColor = Color.FromHex("fff"),
                BackgroundColor = Color.FromHex("76bded"),
                FontSize = 16,
                XAlign = TextAlignment.Center,
            };
            hMonth.SetBinding(Label.TextProperty,
                new Binding("modified", stringFormat: "{0:MM}"));
            var hDay = new Label
            {
                TextColor = Color.FromHex("555"),
                BackgroundColor = Color.FromHex("ececec"),
                FontSize = 30,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            hDay.SetBinding(Label.TextProperty,
                new Binding("modified", stringFormat: "{0:dd}"));
            var hWeekDay = new Label
            {
                TextColor = Color.FromHex("333"),
                BackgroundColor = Color.FromHex("e3e3e3"),
                FontSize = 13,
                XAlign = TextAlignment.Center,
            };
            hWeekDay.SetBinding(Label.TextProperty,
                new Binding("modified", stringFormat: "（{0:ddd}）"));

            var grid = new Grid
            {
                Padding = new Thickness(1, 1, 1, 1),
                RowSpacing = 1,
                ColumnSpacing = 1,
                BackgroundColor = Color.FromHex("dedede"),
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (20, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (18, GridUnitType.Absolute) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (50, GridUnitType.Absolute) },
                },
            };
            grid.Children.Add(hMonth, 0, 0);
            grid.Children.Add(hDay, 0, 1);
            grid.Children.Add(hWeekDay, 0, 2);

            #endregion

            var cell = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 10,
                Children = {
                    grid,
                    new StackLayout
                    {
                        Padding = new Thickness(10, 0, 10, 5),
                        Spacing = 5,
                        Children = {
                            title,
                            contents,
                            auth,
                            date,
                        },
                    },
                }
            };

            this.View = cell;
        }
    }
}
