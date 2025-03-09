namespace Cassie.Domain.Common.Interfaces
{
    public interface IModifierTrackable<TUser>
    {
        TUser LastModifiedBy { get; set; }
    }
}
