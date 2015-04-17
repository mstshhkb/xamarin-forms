using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ScrollViewLimitSample
{
    public class App : Application
    {
        public App()
        {
            var str = "The base of very long sentences.";
            var sb = new StringBuilder();
            for (int i = 0; i < 200; i++)
            {
                sb = sb.Append(string.Format("No.{0}: {1} ", i, str));
            }
            MainPage = new ContentPage
            {
                Content = new ScrollView
                {
                    Content = new Label { Text = sb.ToString() }
                }
            };
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
