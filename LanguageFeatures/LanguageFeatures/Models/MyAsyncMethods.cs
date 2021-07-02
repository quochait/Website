using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;

            //test coi co bang khong nha :) dm
            //var httpMessage = await client.GetStringAsync("http://apress.com");
            //return httpMessage.Length;

            //var httpTask = client.GetAsync("http://apress.com");
            //return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            //{
            //    return antecedent.Result.Content.Headers.ContentLength;
            //});
        }
    }
}
