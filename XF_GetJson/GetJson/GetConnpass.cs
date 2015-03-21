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
    public class GetConnpass
    {
        public static async Task<CPRoot> GetJson(DateTime datefrom, DateTime dateto)
        {
            string mainUri = "http://connpass.com/api/v1/event/?";

            // datefrom から dateto までを ymd=yyyyMMdd,yyyyMMdd とパラメーターに追加
            var timespan = dateto - datefrom;
            var differenceInDay = timespan.Days;

            var sb = new StringBuilder();
            sb.Append("count=100&ymd=");

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
                        str = str.Replace("catch", "_catch");
                        var res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CPRoot>(str, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        return res;
                    }
                }
            }
            return null;
        }
    }


    public class CPRoot
    {

        public class CPEvent
        {
            public string event_url { get; set; }
            public string event_type { get; set; }
            public string owner_nickname { get; set; }
            public Series series { get; set; }
            public DateTime updated_at { get; set; }
            public string lat { get; set; }
            public DateTime started_at { get; set; }
            public string hash_tag { get; set; }
            public string title { get; set; }
            public int event_id { get; set; }
            public string lon { get; set; }
            public int waiting { get; set; }
            public int limit { get; set; }
            public int owner_id { get; set; }
            public string owner_display_name { get; set; }
            public string description { get; set; }
            public string address { get; set; }
            public string _catch { get; set; }
            public int accepted { get; set; }
            public DateTime ended_at { get; set; }
            public string place { get; set; }
        }

        public class Series
        {
            public string url { get; set; }
            public int id { get; set; }
            public string title { get; set; }
        }
        public int results_returned { get; set; }
        public List<CPEvent> events { get; set; }
        public int results_start { get; set; }
        public int results_available { get; set; }
    }

 




}
