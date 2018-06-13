using System.Collections.Generic;
using DevTask.Services.Storage.Model;

namespace DevTask.Services.Storage
{
    public interface IRepository<TEntity, TId> where TEntity : IEntityHasId<TId>
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> Get(IEnumerable<TId> ids = null);
        void Put(TEntity entity);
        void Delete(TId id);
        void Clear();
    }
}