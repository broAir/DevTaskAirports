using System.Threading.Tasks;
using DevTask.Services.Http.Model.Abstract;

namespace DevTask.Services.Http.Abstract
{
    // this is not used in the code but usually i would do it htis way
    public abstract class HttpService<TEntity> : IHttpService<TEntity> where TEntity: IHttpGetResponseModel
    {
        protected string BaseUrl { get; set; }
        protected string GetUrl { get; set; }
        
        // Here would be a composition of get/post/put services
        protected IHttpGetService<TEntity> GetService { get; private set; }

        // to be used in the service factory somewhere
        protected HttpService(string baseUrl, string url, IHttpGetService<TEntity> service)
        {
            BaseUrl = baseUrl;
            GetUrl = url;
            GetService = service;
        }

        public async Task<TEntity> Get()
        {
            var url = FormatUrl(BaseUrl, GetUrl);
            return await GetService.Get(url);
        }

        protected string FormatUrl(string baseUrl, string addUrl)
        {
            return $"{baseUrl}/{addUrl}";
        }
    }

    
    public interface IHttpService<TEntity> where TEntity : IHttpGetResponseModel
    {
        Task<TEntity> Get();
        // Post, put, etc
    }
}