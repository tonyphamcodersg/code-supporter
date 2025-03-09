namespace Cassie.Domain.Common.Interfaces
{
    public interface ICreatorTrackable<TUser>
    {
        TUser CreatedBy { get; set; }
    }
}
