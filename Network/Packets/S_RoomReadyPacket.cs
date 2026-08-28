
namespace block_racing_common.Network.Packets
{
    public class S_RoomReadyPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_RoomReady;

        public long RoomId { get; set; }

        public void Read(PacketReader reader)
        {
            RoomId = reader.ReadLong();
        }

        public void Write(PacketWriter writer)
        {
            writer.Write(RoomId);
        }
    }
}
