using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class C_CreateRoomPacket : IPacket
    {
        public PacketId PacketId => PacketId.C_CreateRoom;


        public void Read(PacketReader reader)
        {

        }


        public void Write(PacketWriter writer)
        {

        }
    }
}