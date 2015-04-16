using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class ListCS : ContentPage
    {
        public ListCS()
        {
            // ItemSource が配列の場合は ItemSource だけで表示できます
            var list = new ListView
            {
                ItemsSource = new string[] { "Taro", "Jiro", "Saburo", "Shiro" }
            };

            Title = "配列からItemTemplateなしでListView";
            Content = list;
        }
    }
}
