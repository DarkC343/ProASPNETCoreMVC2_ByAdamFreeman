using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpLanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var HttpMessage = await client.GetAsync("http://google.com");
            return HttpMessage.Content.Headers.ContentLength;
        }
    }
}
