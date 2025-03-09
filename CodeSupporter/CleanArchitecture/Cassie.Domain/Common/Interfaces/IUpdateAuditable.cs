namespace Cassie.Domain.Common.Interfaces
{
    public interface IUpdateAuditable<TUser> : IModifierTrackable<TUser>, IModifiedTimestamp
    {
    }
}
