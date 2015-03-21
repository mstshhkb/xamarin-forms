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
    public class GetDoorkeeper
    {
        public static async Task<List<DKRoot>> GetJson(DateTime datefrom, DateTime dateto)
        {
            string mainUri = "http://api.doorkeeper.jp/events/?";

            // datefrom と dateto を since=yyyy-MM-dd と until=yyyy-MM-dd に
            string subUri = string.Format("since={0}&until={1}",
                datefrom.ToString("yyyy-MM-dd"), dateto.ToString("yyyy-MM-dd"));

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
                        str = str.Replace("\"event\"", "\"events\"").Replace("long", "_long");
                        var res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<DKRoot>>(str, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        return res;
                    }
                }
            }
            return null;
        }
    }


    public class DKRoot
    {
        public class DKEvent
        {
            public string title { get; set; }
            public int id { get; set; }
            public DateTime starts_at { get; set; }
            public DateTime ends_at { get; set; }
            public string venue_name { get; set; }
            public string address { get; set; }
            public string lat { get; set; }
            public string _long { get; set; }
            public int? ticket_limit { get; set; }
            public DateTime published_at { get; set; }
            public DateTime updated_at { get; set; }
            public string description { get; set; }
            public string public_url { get; set; }
            public int participants { get; set; }
            public int waitlisted { get; set; }
            public Group group { get; set; }
            public string banner { get; set; }
            public class Group
            {
                public int id { get; set; }
                public string name { get; set; }
                public string country_code { get; set; }
                public string logo { get; set; }
                public string description { get; set; }
                public string public_url { get; set; }
            }
        }

        public DKEvent events { get; set; }


    }
}
