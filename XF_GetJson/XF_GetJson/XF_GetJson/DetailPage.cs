using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XF_GetJson
{
    public class DetailPage : ContentPage
    {
        public DetailPage(string str)
        {
            Padding = new Thickness(20.0);
            Title = "Detail Page";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { 
                    new Label { Text = str } 
                    },
            };
        }
    }
}
