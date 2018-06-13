using System.Collections.Generic;
using DevTask.Services.Storage.Model;

namespace DevTask.Services.Storage
{
    // actual data storage
    public interface IDataStore<TEntity, TId> where TEntity : IEntityHasId<TId>
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> Get(IEnumerable<TId> ids = null);
        // Queryable datastore
        // IQueriable<TEntity> Search(TQuery query);
        void Put(TEntity entity);
        void Delete(TId id);
        void Clear();
    }
}