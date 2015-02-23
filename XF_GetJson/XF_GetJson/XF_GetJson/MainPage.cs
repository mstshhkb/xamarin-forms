using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GetJson;
using Xamarin.Forms;

namespace XF_GetJson
{
    public class MainPage : ContentPage
    {
        private ListView list;

        public MainPage()
        {
            var button = new Button
            {
                Text = "Get",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            list = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
            };
            
            button.Clicked += async (sender, e) => {
                var root = await GetJson.GetJson.GetConnpass();
                ShowTitles(root);
                list.IsVisible = true;
            };

            list.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
                await Navigation.PushAsync(new DetailPage((string)e.Item));
            };

            Title = "Get Json";
            Content = new StackLayout
            {
                Children =
                {
                    button,
                    list,
                }
            };
        }

        private void ShowTitles(GetJson.Rootobject root) {
            string[] items = (from x in root.events
                                       select x.title).ToArray();
            list.ItemsSource = items;
        }

        //        private void ShowTitles(GetJson.Rootobject root) {
        //            items = new String[root.events.Count];
        //            for (int i = 0; i < root.events.Count; i++)
        //            {
        //                items[i] = root.events[i].title;
        //            }
        //            list.ItemsSource = items;
        //
        //        }



    }
}
