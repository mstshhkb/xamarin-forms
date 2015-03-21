using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetJson
{
    public class GetAtnd
    {
        public static async Task<ATRoot> GetJson(DateTime datefrom, DateTime dateto)
        {
            string mainUri = "http://api.atnd.org/events/?";

            // datefrom から dateto までを ymd=yyyyMMdd,yyyyMMdd とパラメーターに追加
            var timespan = dateto - datefrom;
            var differenceInDay = timespan.Days;

            var sb = new StringBuilder();
            sb.Append("format=json&count=100&ymd=");

            for (int i = 0; i < differenceInDay; i++)
            {
                sb.Append(datefrom.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(datefrom.AddDays(differenceInDay).ToString("yyyyMMdd"));

            var subUri = sb.ToString();

            // 取得
            var httpclient = new HttpClient();
            var st = await httpclient.GetAsync(mainUri + subUri);
            if (st.IsSuccessStatusCode)
            {
                using (var stream = await st.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var str = await streamReader.ReadToEndAsync();
                        str = str.Replace("\"event\"", "\"_event\"").Replace("catch", "_catch");
                        var res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ATRoot>(str, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        return res;
                    }
                }
            }
            return null;
        }
    }


    // [編集] - [形式を選択して貼り付け] - [JSON をクラスとして貼り付ける]


    public class ATRoot
    {
        public int results_returned { get; set; }
        public int results_start { get; set; }
        public List<ATEvent> events { get; set; }
    }

    public class ATEvent
    {
        public Event1 _event { get; set; }
    }

    public class Event1
    {
        public int event_id { get; set; }
        public string title { get; set; }
        public string _catch { get; set; }
        public string description { get; set; }
        public string event_url { get; set; }
        public DateTime started_at { get; set; }
        public DateTime ended_at { get; set; }
        public string url { get; set; }
        public int? limit { get; set; }
        public string address { get; set; }
        public string place { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public int owner_id { get; set; }
        public string owner_nickname { get; set; }
        public string owner_twitter_id { get; set; }
        public int accepted { get; set; }
        public int waiting { get; set; }
        public DateTime updated_at { get; set; }
    }

}
