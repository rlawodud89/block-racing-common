using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class C_JoinRoomPacket : IPacket
    {
        public PacketId PacketId => PacketId.C_JoinRoom;

        public string RoomCode { get; set; } = string.Empty;


        public void Read(PacketReader reader)
        {
            RoomCode = reader.ReadString();
        }


        public void Write(PacketWriter writer)
        {
            writer.Write(RoomCode);
        }
    }
}