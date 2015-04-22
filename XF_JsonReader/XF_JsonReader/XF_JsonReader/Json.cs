using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XF_JsonReader
{
    class Json
    {
        public static async Task<Root> GetJson()
        {
            using (var client = new HttpClient())
            {
                var str = await client.GetStringAsync("http://xmdemo1.azurewebsites.net/json/feed.json");
                var res = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Root>(str));
                return res;
            }

            #region エラー処理付き
            /* ちゃんと取得チェックをする場合はここから
            // HttpClient をインスタンス化
            using (var client = new HttpClient())
            {
                // url から json を取得
                var st = await client.GetAsync(url + file);
                // status が成功だったら次のコードを実行
                if (st.IsSuccessStatusCode)
                {
                    using (var stream = await st.Content.ReadAsStreamAsync())
                    {
                        using (var streamReader = new StreamReader(stream))
                        {
                            // json を StreamReader で読み取り Root インスタンスを返す 
                            // JsonSerializerSettings として、NullValue を無視する
                            var str = await streamReader.ReadToEndAsync();
                            var response = await Task.Factory.StartNew(() =>
                                JsonConvert.DeserializeObject<Root>(str, new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                }));
                            return response;
                        }
                    }
                }
                return null;
            }
             ここまで */
            #endregion
        }
    }

    /// <summary>
    /// Visual Studio の形式を選択して貼り付けを使用して Json から自動生成したクラスです
    /// </summary>
    public class Root
    {
        public class Article
        {
            public int _id { get; set; }
            public string title { get; set; }
            public DateTime published_date { get; set; }
            public DateTime? updated_date { get; set; }
            public string author { get; set; }
            public string author_div { get; set; }
            public string email { get; set; }
            public string context { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string[] tag { get; set; }
        }
        public List<Article> news { get; set; }
    }
}
