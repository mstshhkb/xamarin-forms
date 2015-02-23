using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XF_ListView
{
    public class ListViewPage : ContentPage
    {

        class parties
        {
            /// <summary>
            /// イベント Method
            /// </summary>
            /// <param name="name">イベント名</param>
            /// <param name="startday">イベント開始日</param>
            public parties(string name, DateTime startday)
            {
                this.Name = name;
                this.Startday = startday;
            }

            public string Name { get; set; }
            public DateTime Startday { get; set; }
        };

        public ListViewPage()
        {
            //string[] events = new string[3] {"test1","test2","test3" }; 
            List<parties> party = new List<parties> {
                new parties("event1", new DateTime(2015,2,1)),
                new parties("event2", new DateTime(2015,1,30)),
                new parties("event3", new DateTime(2015,1,15)),
            };


            var button = new Button
            {
                Text = "test",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var listView = new ListView
            {
                ItemsSource = party,

                // エラー	2	ラムダ式 はデリゲート型ではないため、型 'System.Type' に変換できません。	D:\_dev\VS\XF_ListView\XF_ListView\XF_ListView\ListViewPage.cs	50	49	XF_ListView
                //ItemTemplate = new DataTemplate(() =>
                //{
                //    Label namelabel = new Label();
                //    namelabel.SetBinding(Label.TextProperty, "Name");

                //    Label datelabel = new Label();
                //    datelabel.SetBinding(Label.TextProperty, new Binding("Startday", BindingMode.OneWay, null, null, "{0:d}"));

                //    return new ViewCell
                //    {
                //        View = new StackLayout
                //        {
                //            Padding = new Thickness(10, 5),
                //            Orientation = StackOrientation.Horizontal,
                //            Children = {
                //                datelabel,
                //                namelabel,
                //            }
                //        }
                //    };

                //})

            };


            Content = new StackLayout
            {
                Children = {
					button,
                    listView,
				}
            };
        }
    }
}
