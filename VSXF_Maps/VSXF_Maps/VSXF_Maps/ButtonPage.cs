using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace VSXF_Maps
{
    class ButtonPage : ContentPage
    {
        Map map;

        public ButtonPage()
        {
            map = new Map();
            var position = new Position(35.685402, 139.752826);
            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

            var buttonTokyo = new Button { Text = "Tokyo", HorizontalOptions = LayoutOptions.FillAndExpand };
            var buttonXLsoft = new Button { Text = "XLsoft", HorizontalOptions = LayoutOptions.FillAndExpand };
            var buttonXamarin = new Button { Text = "Xamarin", HorizontalOptions = LayoutOptions.FillAndExpand };

            buttonTokyo.Clicked += HandleClicked;
            buttonXLsoft.Clicked += HandleClicked;
            buttonXamarin.Clicked += HandleClicked;

            Content = new StackLayout {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Vertical,
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            buttonTokyo,
                            buttonXLsoft,
                            buttonXamarin,
                        },
                    },
                    map,
                },
            };

        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Tokyo":
                    map.Pins.Clear();
                    var posTokyo = new Position(35.681382, 139.766084);
                    map.MoveToRegion(new MapSpan(posTokyo, 0.01, 0.01));
                    var pinTokyo = new Pin
                    {
                        Type = PinType.Place,
                        Position = posTokyo,
                        Label = "東京駅",
                        Address = "〒100-0005 東京都千代田区丸の内１丁目９−１"
                    };
                    map.Pins.Add(pinTokyo);
                    break;
                case "XLsoft":
                    map.Pins.Clear();
                    var posXLsoft = new Position(35.641385, 139.740903);
                    map.MoveToRegion(new MapSpan(posXLsoft, 0.01, 0.01));
                    var pinXLsoft = new Pin
                    {
                        Type = PinType.Place,
                        Position = posXLsoft,
                        Label = "エクセルソフト株式会社",
                        Address = "〒108-0073 東京都港区三田３－９－９ 森伝ビル６Ｆ"
                    };
                    map.Pins.Add(pinXLsoft);
                    break;
                case "Xamarin":
                    map.Pins.Clear();
                    var posXamarin = new Position(37.797996, -122.401876);
                    map.MoveToRegion(new MapSpan(posXamarin, 0.01, 0.01));
                    break;
            }
        }
    }
}
