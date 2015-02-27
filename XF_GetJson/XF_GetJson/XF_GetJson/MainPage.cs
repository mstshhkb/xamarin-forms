using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GetConnpass;
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
                Text = "Get Json!",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            list = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            // button click
            button.Clicked += async (sender, e) =>
            {
                var root = await GetConnpass.GetConnpass.GetJson();
                ShowTitles(root);
            };

            // list.ItemTapped
            list.ItemTapped += list_ItemTapped;

            Title = "Get Json";
            Content = new StackLayout
            {
                Children = { 
                    button,
                    list 
                }
            };

        }

        async void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DetailPage((string)e.Item));
        }

        private void ShowTitles(GetConnpass.Rootobject root)
        {
            // LinQ
            string[] items = (from x in root.events
                              select x.title).ToArray();
            list.ItemsSource = items;
        }
    }
}
