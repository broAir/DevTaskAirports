using System.Collections.Generic;
using DevTask.Services.Storage.Map;
using DevTask.Services.Storage.Model;

namespace DevTask.Services.Storage
{
    public abstract class Repository<TDataStore, TDataStoreEntity, TEntity, TId> : IRepository<TEntity, TId> 
        where TEntity : IEntityHasId<TId>
        where TDataStoreEntity : IEntityHasId<TId>
        where TDataStore: IDataStore<TDataStoreEntity, TId>
    {
        protected IMapperFactory EntityMapperFactory { get; set; }
        protected TDataStore DataStore { get; set; }

        protected Repository(TDataStore dataStore, IMapperFactory mapperFactory)
        {
            DataStore = dataStore;
            EntityMapperFactory = mapperFactory;
        }
        
        public TEntity Get(TId id)
        {
            // get the entity from the actual storage
            // cast or convert the entity
            var dataItem = DataStore.Get(id);
            return EntityMapperFactory.ResolveMapper<TDataStoreEntity, TEntity>().Map(dataItem);
        }

        public IEnumerable<TEntity> Get(IEnumerable<TId> ids = null)
        {
            var dataItems = DataStore.Get(ids);
            return EntityMapperFactory.ResolveMapper<TDataStoreEntity, TEntity>().MapMany(dataItems);
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