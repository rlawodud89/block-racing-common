using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_RoomJoinedPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_RoomJoined;

        public RoomJoinResult Result { get; set; }
        public long RoomId { get; set; }


        public void Read(PacketReader reader)
        {
            Result = (RoomJoinResult)reader.ReadByte();
            RoomId = reader.ReadLong();
        }


        public void Write(PacketWriter writer)
        {
            writer.Write((byte)Result);
            writer.Write(RoomId);
        }
    }
}