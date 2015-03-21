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
            var datefrom = new DatePicker
            {
                Format = "yyyy/M/d",
                Date = DateTime.Now,
            };
            var dateto = new DatePicker
            {
                Format = "yyyy/M/d",
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 7),
            };
            var button = new Button
            {
                Text = "Get Json!",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            list = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                // IsVisible = false
            };

            button.Clicked += async (sender, e) =>
            {
                var atroot = await GetJson.GetAtnd.GetJson(datefrom.Date, dateto.Date);
                var cproot = await GetJson.GetConnpass.GetJson(datefrom.Date, dateto.Date);
                var dkroot = await GetJson.GetDoorkeeper.GetJson(datefrom.Date, dateto.Date);
                var eventinfo = (from x in atroot.events
                                 select new EventInfo
                                 {
                                     site = "ATND",
                                     daystring = x._event.started_at.ToString("MM/dd HH:mm"),
                                     title = x._event.title,
                                     event_uri = x._event.event_url,
                                     start_at = x._event.started_at,
                                     end_at = x._event.ended_at,
                                     address = x._event.address,
                                     description = x._event.description
                                 }).Union(
                                from x in cproot.events
                                select new EventInfo
                                {
                                    site = "Connpass",
                                    daystring = x.started_at.ToString("MM/dd HH:mm"),
                                    title = x.title,
                                    event_uri = x.event_url,
                                    start_at = x.started_at,
                                    end_at = x.ended_at,
                                    address = x.address,
                                    description = x.description
                                }).Union(
                                from x in dkroot
                                select new EventInfo
                                {
                                    site = "DoorKeeper",
                                    daystring = x.events.starts_at.ToLocalTime().ToString("MM/dd HH:mm"),
                                    title = x.events.title,
                                    event_uri = x.events.public_url,
                                    start_at = x.events.starts_at.ToLocalTime(),
                                    end_at = x.events.ends_at.ToLocalTime(),
                                    description = x.events.description
                                }).OrderBy(ev => ev.start_at);

                list.ItemsSource = eventinfo;
                list.ItemTemplate = new DataTemplate(typeof(EventCell));
                list.RowHeight = EventCell.RowHeight;

                //foreach (var x in eventinfo)
                //{
                //    var hap = new HtmlAgilityPack.HtmlDocument();
                //    hap.LoadHtml(x.description);
                //    var doc = hap.DocumentNode.InnerText;
                //    doc = doc.Replace("\r", " ").Replace("\n", " ");
                //    if (doc.Length > 50)
                //    {
                //        doc = doc.Substring(0, 50) + "...";
                //    }
                //    Console.WriteLine(string.Format(
                //        "サイト:\t{0}\n名称:\t{1}\nURL:\t{2}\n日時:\t{3}\n\t{4}\n場所:\t{5}\n内容:\t{6}\n",
                //        x.site, x.title, x.event_uri, x.start_at, x.end_at, x.address, doc));
                //}

                //ShowTitles(root);


            };

            // ItemTapped 時の処理
            list.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
                // Item の選択解除
                list.SelectedItem = null;
                // DetailPage にタップした Item の元データを List として渡します
                await Navigation.PushAsync(new DetailPage(e.Item as EventInfo));
            };

            Title = "IT勉強会検索";
            Content = new StackLayout
            {
                Children = { 
                    new StackLayout { 
                        Orientation = StackOrientation.Horizontal, 
                        Children = {
                            datefrom,
                            new Label { Text = "~", VerticalOptions = LayoutOptions.Center, },
                            dateto,
                            button,
                        },
                    },
                    list,
                },
            };

        }


        //private void ShowTitles(GetConnpass.Rootobject root)
        //{
        //    // LINQ
        //    //string[] items = (from x in root.events
        //    //                  select x.title).ToArray();

        //    // LINQ root.events から必要な要素を抽出して List 化
        //    var items = (from x in root.events
        //                 select new
        //                 {
        //                     event_url = x.event_url,
        //                     started_at = x.started_at.ToString("yyyy/MM/dd"),
        //                     title = x.title,
        //                     description = x.description,
        //                     address = x.address
        //                 }).ToList();

        //    list.ItemsSource = items;
        //    list.ItemTemplate = new DataTemplate(typeof(EventCell));
        //    list.RowHeight = EventCell.RowHeight;
        //}
    }


    /// <summary>
    /// EventInfo
    /// </summary>
    public class EventInfo
    {
        public string site { get; set; }
        public string event_uri { get; set; }
        public string daystring { get; set; }
        public DateTime start_at { get; set; }
        public DateTime end_at { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string address { get; set; }

    }

    /// <summary>
    /// ItemTemplate として ViewCell を元に新しい Cell を用意します
    /// </summary>
    public class EventCell : ViewCell
    {
        public const int RowHeight = 65;

        public EventCell()
        {
            var nameLabel = new Label { 
                FontAttributes = FontAttributes.Bold,
                LineBreakMode = LineBreakMode.TailTruncation,
                // 確認用 BackgroundColor = Color.FromHex("3498DB")
            };
            // root.events の title と ラベルテキストを Binding
            nameLabel.SetBinding(Label.TextProperty, "title");

            var dateLabel = new Label { TextColor = Color.Gray };
            dateLabel.SetBinding(Label.TextProperty, "daystring");

            var siteLabel = new Label { TextColor = Color.Red };
            siteLabel.SetBinding(Label.TextProperty, "site");

            var addressLabel = new Label
            {
                TextColor = Color.Gray,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            addressLabel.SetBinding(Label.TextProperty, "address");

            View = new StackLayout
            {
                Spacing = 3,
                Padding = new Thickness(3,10),
                Children = {
                    nameLabel, 
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            dateLabel,
                            siteLabel,
                            addressLabel,
                        },
                    },
                },
            };
        }
    }

}
