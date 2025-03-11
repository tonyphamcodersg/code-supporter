namespace Cassie.Domain.Common.Interfaces
{
    public interface ICreationAuditable<TUser> : ICreatorTrackable<TUser>, ICreatedTimestamp
    {
    }
}
