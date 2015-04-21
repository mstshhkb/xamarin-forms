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
        private ActivityIndicator indicator;
        //private IEnumerable<EventInfo> eventinfo;


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
                Date = DateTime.Now.AddDays(3),
            };
            datefrom.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                dateto.Date = datefrom.Date.AddDays(3);
            };
            var button = new Button
            {
                Text = "取得",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            indicator = new ActivityIndicator
            {
                Color = Color.Default,
                IsRunning = false,
                IsVisible = false,
            };

            var memo = new Label
            {
                Text = "Connpass, ATND, DoorKeeper から指定した日付のイベントをリストします。",
            };

            list = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false
            };

            Title = "IT勉強会検索";
            Content = new StackLayout
            {
                Padding = 3,
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
                    indicator,
                    memo,
                    list,
                },
            };

            // button Tap 時の動作
            button.Clicked += async (sender, e) =>
            {
                memo.IsVisible = false;
                list.IsVisible = false;
                indicator.IsRunning = true;
                indicator.IsVisible = true;

                var atroot = await GetAtnd.GetJson(datefrom.Date, dateto.Date);
                var cproot = await GetConnpass.GetJson(datefrom.Date, dateto.Date);
                var dkroot = await GetDoorkeeper.GetJson(datefrom.Date, dateto.Date);

                if (atroot == null ||cproot==null||dkroot == null)
                {
                    System.Diagnostics.Debug.WriteLine("Fetch data error");
                }

                //ShowTitles(root);
                var eventinfo = (from x in atroot.events
                                 where !(x._event.title.Contains("恋活") || x._event.title.Contains("婚活") ||x._event.title.Contains("パーティ") ||x._event.title.Contains("Party") ||x._event.title.Contains("副業") ||x._event.title.Contains("グルメ") )
                                 select new EventInfo
                                 {
                                     site = "ATND",
                                     daystring = string.Format("{0}~{1}", x._event.started_at.ToString("MM/dd HH:mm"), x._event.ended_at.ToString("HH:mm")),
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
                                    daystring = string.Format("{0}~{1}", x.started_at.ToString("MM/dd HH:mm"), x.ended_at.ToString("HH:mm")),
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
                                    daystring = string.Format("{0}~{1}", x.events.starts_at.ToLocalTime().ToString("MM/dd HH:mm"), x.events.ends_at.ToLocalTime().ToString("HH:mm")),
                                    title = x.events.title,
                                    event_uri = x.events.public_url,
                                    start_at = x.events.starts_at.ToLocalTime(),
                                    end_at = x.events.ends_at.ToLocalTime(),
                                    address = x.events.address,
                                    description = x.events.description
                                }).OrderBy(ev => ev.start_at);

                indicator.IsRunning = false;
                indicator.IsVisible = false;

                list.IsVisible = true;
                list.ItemsSource = eventinfo;
                list.ItemTemplate = new DataTemplate(typeof(EventCell));
                list.RowHeight = EventCell.RowHeight;
            };

            // ItemTapped 時の処理
            list.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                // Item の選択解除
                list.SelectedItem = null;
                // DetailPage にタップした Item の元データを List として渡します
                await Navigation.PushAsync(new DetailPage(e.Item as EventInfo));
            };

        }


        // 画面表示時に自動的に当日から 2日後までのデータを読み込み表示
        // TODO: Refresh 時にも呼ばれてしまうので、初回起動時のみにしたいです。。。
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var datefrom = DateTime.Now;
        //    var dateto = datefrom.AddDays(2);

        //    indicator.IsRunning = true;
        //    indicator.IsVisible = true;

        //    var atroot = await GetAtnd.GetJson(datefrom.Date, dateto.Date);
        //    var cproot = await GetConnpass.GetJson(datefrom.Date, dateto.Date);
        //    var dkroot = await GetDoorkeeper.GetJson(datefrom.Date, dateto.Date);
            
        //    //ShowTitles(atroot, cproot, dkroot);
        //    var eventinfo = (from x in atroot.events
        //                     select new EventInfo
        //                     {
        //                         site = "ATND",
        //                         daystring = string.Format("{0}~{1}", x._event.started_at.ToString("MM/dd HH:mm"), x._event.ended_at.ToString("HH:mm")),
        //                         title = x._event.title,
        //                         event_uri = x._event.event_url,
        //                         start_at = x._event.started_at,
        //                         end_at = x._event.ended_at,
        //                         address = x._event.address,
        //                         description = x._event.description
        //                     }).Union(
        //                    from x in cproot.events
        //                    select new EventInfo
        //                    {
        //                        site = "Connpass",
        //                        daystring = string.Format("{0}~{1}", x.started_at.ToString("MM/dd HH:mm"), x.ended_at.ToString("HH:mm")),
        //                        title = x.title,
        //                        event_uri = x.event_url,
        //                        start_at = x.started_at,
        //                        end_at = x.ended_at,
        //                        address = x.address,
        //                        description = x.description
        //                    }).Union(
        //                    from x in dkroot
        //                    select new EventInfo
        //                    {
        //                        site = "DoorKeeper",
        //                        daystring = string.Format("{0}~{1}", x.events.starts_at.ToLocalTime().ToString("MM/dd HH:mm"), x.events.ends_at.ToLocalTime().ToString("HH:mm")),
        //                        title = x.events.title,
        //                        event_uri = x.events.public_url,
        //                        start_at = x.events.starts_at.ToLocalTime(),
        //                        end_at = x.events.ends_at.ToLocalTime(),
        //                        address = x.events.address,
        //                        description = x.events.description
        //                    }).OrderBy(ev => ev.start_at);

        //    indicator.IsRunning = false;
        //    indicator.IsVisible = false;

        //    list.ItemsSource = eventinfo;
        //    list.ItemTemplate = new DataTemplate(typeof(EventCell));
        //    list.RowHeight = EventCell.RowHeight;
        //}

        //private void ShowTitles(GetJson.ATRoot atroot, GetJson.CPRoot cproot, GetJson.DKRoot dkroot)
        //{
        //    var eventinfo = (from x in atroot.events
        //                     select new EventInfo
        //                     {
        //                         site = "ATND",
        //                         daystring = x._event.started_at.ToString("MM/dd HH:mm"),
        //                         title = x._event.title,
        //                         event_uri = x._event.event_url,
        //                         start_at = x._event.started_at,
        //                         end_at = x._event.ended_at,
        //                         address = x._event.address,
        //                         description = x._event.description
        //                     }).Union(
        //                    from x in cproot.events
        //                    select new EventInfo
        //                    {
        //                        site = "Connpass",
        //                        daystring = x.started_at.ToString("MM/dd HH:mm"),
        //                        title = x.title,
        //                        event_uri = x.event_url,
        //                        start_at = x.started_at,
        //                        end_at = x.ended_at,
        //                        address = x.address,
        //                        description = x.description
        //                    }).Union(
        //                    from x in dkroot
        //                    select new EventInfo
        //                    {
        //                        site = "DoorKeeper",
        //                        daystring = x.events.starts_at.ToLocalTime().ToString("MM/dd HH:mm"),
        //                        title = x.events.title,
        //                        event_uri = x.events.public_url,
        //                        start_at = x.events.starts_at.ToLocalTime(),
        //                        end_at = x.events.ends_at.ToLocalTime(),
        //                        description = x.events.description
        //                    }).OrderBy(ev => ev.start_at);

        //    list.ItemsSource = eventinfo;
        //    list.ItemTemplate = new DataTemplate(typeof(EventCell));
        //    //list.RowHeight = EventCell.RowHeight;
        //}
    }


    /// <summary>
    /// 各 Json からのイベント情報を EventInfo に格納します
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
        public const int RowHeight = 100;

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

            var siteLabel = new Label { TextColor = Color.Silver };
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
                        },
                    },
                    addressLabel
                },
            };
        }
    }

}
