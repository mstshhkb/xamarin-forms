using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GetJson;
using Xamarin.Forms;

namespace XF_GetJson
{
    public class MainPageCS : ContentPage
    {
        private ListView list;
        private string[] items;

        public MainPageCS()
        {
            var button = new Button
            {
                Text = "Get Connpass",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                
            };
            list = new ListView();

            
            button.Clicked += async (sender, e) =>
            {
                var root = await GetJson.GetJson.GetConnpass();
                ShowTitles(root);
            };

            Title = "Get Json";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
					button,
                    list,
				}
            };
        }

        private void ShowTitles(GetJson.Rootobject root)
        {
            items = new String[root.events.Count];
            for (int i = 0; i < root.events.Count; i++)
            {
                items[i] = root.events[i].title;
            }
            list.ItemsSource = items;

        }
    }
}
