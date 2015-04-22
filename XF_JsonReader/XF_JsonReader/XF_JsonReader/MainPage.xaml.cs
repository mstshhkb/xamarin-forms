using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XF_JsonReader
{
    public partial class MainPage : ContentPage
    {
        Root root;
        public MainPage()
        {
            InitializeComponent();
        }

        // ListView の Item がタップされた時の処理です。
        // DetailPage にタップした Item の元データを List<Article> として渡しています。
        async void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            list.SelectedItem = null;
            await Navigation.PushAsync(new DetailPage(e.Item as Root.Article));
        }

        // 画面表示時の処理
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!list.IsVisible)
            {
                // クルクル表示
                indicator.IsRunning = true;
                indicator.IsVisible = true;

                // Json を取得して ItemsSource に指定
                root = await Json.GetJson();
                list.ItemsSource = root.news;

                // クルクル停止＆非表示
                indicator.IsRunning = false;
                indicator.IsVisible = false;
                label.IsVisible = false;
                // ListView 表示
                list.IsVisible = true;
            }
        }
    }
}
