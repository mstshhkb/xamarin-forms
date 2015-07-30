using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF_JsonReader.Views;

namespace XF_JsonReader
{
    public class App : Application
    {
        public App()
        {
            var nav = new NavigationPage(new MainPageXaml());
            nav.BarBackgroundColor = Color.FromHex("3498DB");
            if (Device.OS == TargetPlatform.Windows)
            {
                nav.BarTextColor = Color.Black;
            }
            else
            {
                nav.BarTextColor = Color.White;
            }
            MainPage = nav;

            #region Windows Phone 用ラベルスタイル
            if (Device.OS == TargetPlatform.Windows)
            {
                Application.Current.Resources = new ResourceDictionary();
                var labelStyle = new Style(typeof(Label))
                {
                    Setters = {
                        new Setter { Property = Label.FontSizeProperty, Value = 25 },
                    }
                };
                Application.Current.Resources.Add(labelStyle);
            };
            #endregion
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
