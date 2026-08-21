using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class C_ExitRoomPacket : IPacket
    {
        public PacketId PacketId => PacketId.C_ExitRoom;

        public void Read(PacketReader reader)
        {

        }


        public void Write(PacketWriter writer)
        {

        }
    }
}