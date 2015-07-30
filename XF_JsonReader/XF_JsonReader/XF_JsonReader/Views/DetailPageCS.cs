using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XF_JsonReader.Models;

namespace XF_JsonReader.Views
{
    public class DetailPageCS : ContentPage
    {
        public DetailPageCS(RootObject.Post post)
        {
            this.BindingContext = post;


            var title = new Label
            {
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("22638e"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            title.SetBinding(Label.TextProperty, "title");

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
                new Binding("modified", stringFormat: "更新日時： {0:yyyy/MM/dd HH:mm}"));

            // Label に TapGestureRecognizer を追加してタップすると Uri を開くようにします。
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (sender, e) =>
            {
                // ブラウザで Uri を開く
                Device.OpenUri(new Uri(post.url));
            };
            var url = new Label
            {
                TextColor = Color.FromHex("4b7ee5"),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            url.SetBinding(Label.TextProperty, "url");
            url.GestureRecognizers.Add(tgr);

            var hrbar = new BoxView
            {
                Color = Color.FromHex("2d82b7"),
                HeightRequest = 1,
            };

            var contents = new Label();
            contents.SetBinding(Label.TextProperty,
                new Binding("content", converter: new Converters.HtmlToPlainConverter()));

            // Binding なので PostCell を使いまわせます。
            var cell = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = 25,
                    Spacing = 10,
                    Children = {
                        title,
                        auth,
                        date,
                        url,
                        hrbar,
                        contents,
                    }
                }
            };

            Title = post.title;
            Content = cell;
        }

    }
}
