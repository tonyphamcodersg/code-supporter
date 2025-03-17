namespace Cassie.Domain.Common.Interfaces
{
    public interface IEntityId<TKey>
    {
        TKey Id { get; set; }
    }
}
