using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace VSXF_Maps
{
    class InputPage : ContentPage
    {
        Map map;

        public InputPage()
        {
            map = new Map();
            var position = new Position(35.685402, 139.752826);
            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

            var button = new Button { Text = "Move!" };

            var input1 = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "34.702485",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var input2 = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "135.495951",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            button.Clicked += (sender, e) =>
            {
                try
                {
                    var newposition = new Position(double.Parse(input1.Text), double.Parse(input2.Text));
                    map.MoveToRegion(new MapSpan(newposition, 0.01, 0.01));
                }
                catch (FormatException)
                {
                    DisplayAlert(null, "数値を入力してください", "OK");
                }
                
            };

            Content = new StackLayout {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
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
