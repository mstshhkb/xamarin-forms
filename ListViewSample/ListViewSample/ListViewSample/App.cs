using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ListViewSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new NavigationPage(new StartPage());
            MainPage = new ListXaml_CustomCell();
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

    public class StartPage : ContentPage
    {
        public StartPage()
        {
            var header = new Style(typeof(Label))
            {
                Setters = {
                    new Setter {Property = Label.FontSizeProperty, Value = 20 },
                    new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter {Property = Label.TextColorProperty, Value = Color.White },
                    new Setter {Property = Label.BackgroundColorProperty, Value = Color.Gray },
                    new Setter {Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.FillAndExpand },
                    new Setter {Property = Label.MinimumHeightRequestProperty, Value = 30 },
                }
            };

            Title = "ListView実装方法サンプル";
            Content = new StackLayout
            {
                Children = {
                    new Label { 
                        Text = "C#",
                        Style = header,
                    },
                    new Button {
                        Text = "配列でListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListCS()))
                    },
                    new Button {
                        Text = "List<T>でTextCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListCS_TextCell()))
                    },
                    new Button {
                        Text = "List<T>でImageCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListCS_ImageCell()))
                    },
                    new Button {
                        Text = "List<T>でCustomCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListCS_CustomCell()))
                    },
                    new Label { 
                        Text = "Xaml",
                        Style = header,
                    },
                    new Button {
                        Text = "配列でListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListXaml()))
                    },
                    new Button {
                        Text = "List<T>でTextCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListXaml_TextCell()))
                    },
                    new Button {
                        Text = "List<T>でImageCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListXaml_ImageCell()))
                    },
                    new Button {
                        Text = "List<T>でCustomCellのListView",
                        Command = new Command(async () => await Navigation.PushAsync(new ListXaml_CustomCell()))
                    },
                }
            };
        }
    }
}
