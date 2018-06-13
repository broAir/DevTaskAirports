namespace DevTask.Services.Storage.Model
{
    public interface IEntityHasId<TId>
    {
        TId ID { get; set; }
    }
}