using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_HeartbeatPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_Heartbeat;


        public void Read(PacketReader reader)
        {

        }


        public void Write(PacketWriter writer)
        {

        }
    }
}