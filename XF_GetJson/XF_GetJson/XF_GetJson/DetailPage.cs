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
            // items.description に HTML タグが入っているので除去
            var hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(items.description);
            var doc = hap.DocumentNode.InnerText;

            // Tap 時の動作
            var tap = new TapGestureRecognizer();
            tap.Tapped += (sender, e) =>
            {
                // ブラウザで Uri を開く
                Device.OpenUri(new Uri(items.event_uri));
            };

            // Labe を継承した LinkedLabel をインスタンス化し、Tap 時の動作を追加
            var linkedlabel = new LinkedLabel
            {
                Text = items.event_uri,
                TextColor = Color.FromHex("4b7ee5"),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            linkedlabel.GestureRecognizers.Add(tap);


            Padding = new Thickness(5);
            Title = "詳細";
            
            // Grid Layout 定義
            var grid = new Grid {
                RowSpacing = 7,
                ColumnSpacing = 12,
                RowDefinitions = new RowDefinitionCollection {
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
            }, 0, 2, 0, 1);
            
            // URL
            grid.Children.Add(linkedlabel, 0, 2, 1, 2);
            
            // Date
            grid.Children.Add(new Label { 
                Text = "日時:", 
                FontAttributes = FontAttributes.Bold, 
                TextColor = Color.Gray
            }, 0, 2 );
            grid.Children.Add(new Label { 
                Text = items.daystring,
                TextColor = Color.Gray 
            }, 1, 2);
            
            // Address
            grid.Children.Add(new Label { 
                Text = "場所:", 
                FontAttributes = FontAttributes.Bold, 
                TextColor = Color.Gray 
            }, 0, 3);
            grid.Children.Add(new Label { 
                Text = items.address, 
                TextColor = Color.Gray,
                LineBreakMode = LineBreakMode.TailTruncation 
            }, 1, 3);

            // Description (ScrollView)
            grid.Children.Add(new ScrollView { 
                Content = new Label { 
                    Text = doc 
                } 
            }, 0, 2, 4, 5);

            Content = grid;
        }

    }

    // Label クラスを継承した LinkedLabel クラスを作成
    public class LinkedLabel : Label { }

}
