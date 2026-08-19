using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class C_LeaveRoomPacket : IPacket
    {
        public PacketId PacketId => PacketId.C_LeaveRoom;

        public void Read(PacketReader reader)
        {

        }


        public void Write(PacketWriter writer)
        {

        }
    }
}