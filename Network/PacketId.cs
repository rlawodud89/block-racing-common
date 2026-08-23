
namespace block_racing_common.Network
{
    public enum PacketId : ushort
    {
        // Client to Server
        C_Login = 0,
        C_MatchRequest = 1,
        C_Ready = 2,
        C_Input = 3,
        C_CreateRoom = 4,
        C_JoinRoom = 5,
        C_CloseRoom = 6,
        C_RematchRequest = 7,
        C_ExitRoom = 8,
        C_Heartbeat = 9,

        // Server to Client
        S_Login = 100,
        S_RoomReady = 101,
        S_StartGame = 102,
        S_GameState = 103,
        S_GameEnd = 104,
        S_GameCanceled = 105,
        S_RoomCreated = 106,
        S_RoomJoined = 107,
        S_OpponentExit = 108,
        S_Heartbeat = 109,
    }
}
