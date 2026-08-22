
namespace block_racing_common.Game.Enums
{
    public enum RoomJoinResult : byte
    {
        Success,

        AlreadyQueued,
        AlreadyInRoom,

        RoomNotFound,
        RoomFull,
        UnknownError
    }
}
