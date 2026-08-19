using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_RoomCreatedPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_RoomCreated;

        public bool Success { get; set; }
        public int RoomId { get; set; }
        public string RoomCode { get; set; } = string.Empty;


        public void Read(PacketReader reader)
        {
            Success = reader.ReadBool();
            RoomId = reader.ReadInt32();
            RoomCode = reader.ReadString();
        }


        public void Write(PacketWriter writer)
        {
            writer.Write(Success);
            writer.Write(RoomId);
            writer.Write(RoomCode);
        }
    }
}