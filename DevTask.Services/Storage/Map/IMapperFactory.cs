namespace DevTask.Services.Storage.Map
{
    public interface IMapperFactory
    {
        IEntityMapper<TIn, TOut> ResolveMapper<TIn, TOut>();
    }
}