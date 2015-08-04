using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XF_JsonReader.Models;

namespace XF_JsonReader.Views
{
    public class MainPageCS : ContentPage
    {
        RootObject root;
        ListView listViewCS;
        ContentView layerCS;
        GetWordPressJson gj = new GetWordPressJson();

        public MainPageCS()
        {
            #region 最初に表示する黒いレイヤーです。
            layerCS = new ContentView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Black,
                Opacity = 0.6d,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Spacing = 40,
                    Opacity = 1d,
                    Children = {
                        new Label{
                            Text = "WordPress サイトから Json データを取得しています。",
                            TextColor = Color.White,
                            XAlign = TextAlignment.Center,
                        },
                        new ActivityIndicator
                        {
                            Color = Color.White,
                            IsRunning = true,
                            Scale = 1.5,
                        },
                    },
                }
            };
            #endregion

            listViewCS = new ListView
            {
                HasUnevenRows = true,
                IsVisible = false,
                ItemTemplate = new DataTemplate(typeof(PostCell)), // PostCell テンプレート
            };
            listViewCS.ItemTapped += listViewCS_ItemTapped;

            Title = "社内報 Reader";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    layerCS,
                    listViewCS,
                }
            };
        }

        /// <summary>
        /// 画面表示時に呼び出されるメソッドです。async/await 可能。
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Json データを取得して、ListView の ItemsSource に指定します。
            try
            {
                root = await gj.GetWordpressJsonAsync();
                listViewCS.ItemsSource = root.posts;

                // データが取得出来たら黒いクルクルレイヤーを非表示、ListView を表示します。
                layerCS.IsVisible = false;
                listViewCS.IsVisible = true;
            }
            catch (Exception e)
            {
                layerCS.IsVisible = false;
                await DisplayAlert("エラー", $"通信エラーが発生しました。\n{e.Message}", "OK");
            }
        }

        /// <summary>
        /// ListView の Item Tap メソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void listViewCS_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listViewCS.SelectedItem = null;
            await Navigation.PushAsync(new DetailPageCS(e.Item as RootObject.Post));
        }

    }
}
