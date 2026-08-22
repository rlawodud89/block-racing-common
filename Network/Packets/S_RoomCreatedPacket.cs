using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_RoomCreatedPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_RoomCreated;

        public RoomCreateResult Result { get; set; }
        public int RoomId { get; set; }
        public string RoomCode { get; set; } = string.Empty;


        public void Read(PacketReader reader)
        {
            Result = (RoomCreateResult)reader.ReadByte();
            RoomId = reader.ReadInt32();
            RoomCode = reader.ReadString();
        }


        public void Write(PacketWriter writer)
        {
            writer.Write((byte)Result);
            writer.Write(RoomId);
            writer.Write(RoomCode);
        }
    }
}