using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using HtmlAgilityPack;
using Xamarin.Forms;

namespace XF_GetJson
{
    public class DetailPage : ContentPage
    {
        public DetailPage(EventInfo items)
        {
            // List<Event> の items.description に HTML タグが入っているので除去
            var hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(items.description);
            var doc = hap.DocumentNode.InnerText;

            var tap = new TapGestureRecognizer();
            tap.Tapped += (sender, e) =>
            {
                //tap action here.
                // Open in Web Browser
                Device.OpenUri(new Uri(items.event_uri));
            };

            var linkedlabel = new LinkedLabel
            {
                Text = items.event_uri,
                TextColor = Color.Maroon,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            linkedlabel.GestureRecognizers.Add(tap);


            Padding = new Thickness(5);
            Title = "詳細";
            //Content = new StackLayout
            //{
            //    Padding = 5,
            //    Children = { 
            //        new Label { Text = items.title },
            //        new Label { Text = items.started_at.ToString("yyyy/MM/dd") },
            //        linkedlabel,
            //        new Label { Text = items.address },
            //        new Label { Text = doc }
            //        },
            //};
            var grid = new Grid {
                RowSpacing = 5,
                ColumnSpacing = 12,
                RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions = new ColumnDefinitionCollection {
                    new ColumnDefinition{ Width = GridLength.Auto, },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                },
            };
            // Title
            grid.Children.Add(new Label {
                Text = items.title,
                FontSize = 22, 
                FontAttributes = FontAttributes.Bold,
                // 確認用 BackgroundColor = Color.FromHex("3498DB")
            }, 0, 2, 0, 1);
            
            // URL
            grid.Children.Add(linkedlabel, 0, 2, 1, 2);
            
            // Date
            grid.Children.Add(new Label { Text = "日時:", FontAttributes = FontAttributes.Bold, TextColor = Color.Gray }, 0, 1, 2, 4 );
            grid.Children.Add(new Label { Text = items.start_at.ToString("yyyy/MM/dd HH:mm"), TextColor = Color.Gray }, 1, 2);
            grid.Children.Add(new Label { Text = items.end_at.ToString("yyyy/MM/dd HH:mm"), TextColor = Color.Gray }, 1, 3);
            
            // Address
            grid.Children.Add(new Label { Text = "場所:", FontAttributes = FontAttributes.Bold, TextColor = Color.Gray }, 0, 4);
            grid.Children.Add(new Label { Text = items.address, TextColor = Color.Gray, LineBreakMode = LineBreakMode.TailTruncation }, 1, 4);

            // Description
            grid.Children.Add(new Label { Text = doc }, 0, 2, 5, 6);

            Content = grid;
        }

    }

    public class LinkedLabel : Label { }

}
