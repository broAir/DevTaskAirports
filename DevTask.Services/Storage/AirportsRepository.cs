using DevTask.Services.Storage.Map;
using DevTask.Services.Storage.Model;
using DevTask.Services.Storage.SQL;

namespace DevTask.Services.Storage
{
    public class AirportsRepository : 
        Repository<ISqlDataStore, ISqlDataStoreModel, IAirportsRepositoryItem, string>,
        IAirportsRepository
    {
        public AirportsRepository(ISqlDataStore dataStore, IMapperFactory mapperFactory) : base(dataStore,
            mapperFactory)
        {
        }
    }

    public interface IAirportsRepository : IRepository<IAirportsRepositoryItem, string>
    {

    }
}