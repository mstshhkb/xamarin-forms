using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XF_Maps
{
    public class InputPage : ContentPage
    {
        Map map;

        public InputPage()
        {
            map = new Map();
            var position = new Position (35.685402, 139.752826);
            map.MoveToRegion (new MapSpan (position, 0.01, 0.01));

            var button = new Button{
                Text = "Move!",
            };

            var input1 = new Entry{
                Keyboard = Keyboard.Numeric,
                Placeholder = "35.xxxxxx",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var input2 = new Entry{ 
                Keyboard = Keyboard.Numeric,
                Placeholder = "139.xxxxxx",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            button.Clicked += (sender, e) => {
                var newposition = new Position ( double.Parse(input1.Text), double.Parse(input2.Text));
                map.MoveToRegion (new MapSpan (newposition, 0.01, 0.01));
            };



            Content = new StackLayout
            {
                Padding = new Thickness (0, 20, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            input1,
                            input2,
                            button,
                        },
                    },
                    map,
                },
            };

        }
    }
}

