using System.Collections.Generic;
using DevTask.Services.Storage.Model;

namespace DevTask.Services.Storage
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> 
        where TEntity : IEntityHasId<TId>
    {
        protected IDataStore<IEntityHasId<TId>, TId> DataStore { get; set; }   
        
        public TEntity Get(TId id)
        {
            return (TEntity) DataStore.Get(id);
        }

        public IEnumerable<TEntity> Get(IEnumerable<TId> ids = null)
        {
            return (IEnumerable<TEntity>) DataStore.Get(ids);
        }

        public void Put(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TId id)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}