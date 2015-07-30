using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using HtmlAgilityPack;

namespace XF_JsonReader.Models
{
    class GetWordPressJson
    {
        public async Task<RootObject> GetWordpressJsonAsync()
        {
            var uri = new Uri("http://xmdemo1.azurewebsites.net/?json=get_posts");

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode(); // Status チェック

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var streamReader = new StreamReader(stream))
                        {
                            var json = await streamReader.ReadToEndAsync();
                            var res = JsonConvert.DeserializeObject<RootObject>(json);
                            return res;
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
                return null;
                //throw;
            }
        }
    }
}
