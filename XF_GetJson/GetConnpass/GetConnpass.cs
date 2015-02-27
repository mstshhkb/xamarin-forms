using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetConnpass
{
    public class GetConnpass
    {
        public static async Task<Rootobject> GetJson()
        {
            var httpclient = new HttpClient();
            var st = await httpclient.GetAsync("http://connpass.com/api/v1/event/?keyword_or=xamarin,microsoft&count=100");
            if (st.IsSuccessStatusCode)
            {
                using (var stream = await st.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var str = await streamReader.ReadToEndAsync();
                        var res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Rootobject>(str, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        return res;
                    }
                }
            }
            return null;
        }
    }

    // [編集] - [形式を選択して貼り付け] - [JSON をクラスとして貼り付ける]
    public class Rootobject
    {

        public class Event
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
        public List<Event> events { get; set; }
        public int results_start { get; set; }
        public int results_available { get; set; }
    }

 




}
