using System.Threading.Tasks;
using DevTask.Services.Http.Model.Abstract;

namespace DevTask.Services.Http.Abstract
{
    public interface IHttpGetService<TEntity> where TEntity:IHttpGetResponseModel
    {
        Task<TEntity> Get(string url);
    }
}