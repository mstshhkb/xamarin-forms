using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XF_JsonReader.Models;

namespace XF_JsonReader.Views
{
    public partial class MainPageXaml : ContentPage
    {
        RootObject root;
        GetWordPressJson gj = new GetWordPressJson();
        public MainPageXaml()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ListView の Item Tap メソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void listViewXaml_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listViewXaml.SelectedItem = null;
            await Navigation.PushAsync(new DetailPageXaml(e.Item as RootObject.Post));
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
                listViewXaml.ItemsSource = root.posts;

                // データが取得出来たら黒いクルクルレイヤーを非表示、ListView を表示します。
                layerXaml.IsVisible = false;
                listViewXaml.IsVisible = true;
            }
            catch (Exception e)
            {
                layerXaml.IsVisible = false;
                await DisplayAlert("エラー", $"通信エラーが発生しました。\n{e.Message}", "OK");
            }

        }
    }
}
