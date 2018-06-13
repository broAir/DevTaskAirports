using System.Collections.Generic;

namespace DevTask.Services.Storage.Map
{
    // usually I would use an automapper 
    public interface IEntityMapper<TIn, TOut>
    {
        TOut Map(TIn entityToMap);
        IEnumerable<TOut> MapMany(IEnumerable<TIn> entities);
    }
}