using System.Net.Http;
using System.Threading.Tasks;
using DevTask.Services.Http.Model.Abstract;
using Newtonsoft.Json;

namespace DevTask.Services.Http.Abstract
{
    public abstract class HttpGetService<TEntity> : IHttpGetService<TEntity> where TEntity : IHttpGetResponseModel
    {
        public async Task<TEntity> Get(string url)
        {
            using (var httpClient = new HttpClient())
            {
                //trycatch to handle errors somehow
                var result = await httpClient.GetAsync(url);
                return JsonConvert.DeserializeObject<TEntity>(await result.Content.ReadAsStringAsync());
            }
        }
    }
}