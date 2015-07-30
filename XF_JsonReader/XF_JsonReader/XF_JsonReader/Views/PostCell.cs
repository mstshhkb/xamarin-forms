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
                new Binding("modified", stringFormat: "更新日時： {0:yyyy/MM/dd HH:mm}"));

            var cell = new StackLayout
            {
                Padding = 20,
                Children = {
                    title,
                    contents,
                    auth,
                    date,
                }
            };

            this.View = cell;
        }
    }
}
