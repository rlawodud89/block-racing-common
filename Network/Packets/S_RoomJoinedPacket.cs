using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_RoomJoinedPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_RoomJoined;

        public bool Success { get; set; }
        public int RoomId { get; set; }


        public void Read(PacketReader reader)
        {
            Success = reader.ReadBool();
            RoomId = reader.ReadInt32();
        }


        public void Write(PacketWriter writer)
        {
            writer.Write(Success);
            writer.Write(RoomId);
        }
    }
}