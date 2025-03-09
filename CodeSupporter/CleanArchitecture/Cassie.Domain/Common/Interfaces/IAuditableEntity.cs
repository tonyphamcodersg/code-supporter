namespace Cassie.Domain.Common.Interfaces
{
    public interface IAuditableEntity<TUser> : ICreationAuditable<TUser>, IUpdateAuditable<TUser>
    {
    }
}
