
namespace block_racing_common.Game.Enums
{
    public enum RoomCreateResult : byte
    {
        Success,

        AlreadyQueued,
        AlreadyInRoom,

        RoomLimitExceeded,
        UnknownError
    }
}
