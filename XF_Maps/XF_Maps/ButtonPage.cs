using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XF_Maps
{
    public class ButtonPage : ContentPage
    {
        Map map;

        public ButtonPage()
        {
            map = new Map();
            var position = new Position(35.685402, 139.752826);
            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

            var buttonTokyo = new Button{ Text = "Tokyo" };
            var buttonXLsoft = new Button { Text = "XLsoft" };
            var buttonXamarin = new Button { Text = "Xamarin" };

            buttonTokyo.Clicked += HandleClicked;
            buttonXLsoft.Clicked += HandleClicked;
            buttonXamarin.Clicked += HandleClicked;


            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            buttonTokyo,
                            buttonXLsoft,
                            buttonXamarin,
                        },
                    },
                    map,
                },
            };

        }

        void HandleClicked(object sender, EventArgs e) {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Tokyo":
                    var posTokyo = new Position(35.681382, 139.766084);
                    map.MoveToRegion(new MapSpan(posTokyo, 0.01, 0.01));
                    break;
                case "XLsoft":
                    var posXLsoft = new Position(35.641385, 139.740903);
                    map.MoveToRegion(new MapSpan(posXLsoft, 0.01, 0.01));
                    break;
                case "Xamarin":
                    var posXamarin = new Position(37.797996, -122.401876);
                    map.MoveToRegion(new MapSpan(posXamarin, 0.01, 0.01));
                    break;
            }
        }
    }
}

