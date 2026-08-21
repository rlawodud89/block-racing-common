using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_OpponentExitPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_OpponentExit;

        public void Read(PacketReader reader)
        {

        }


        public void Write(PacketWriter writer)
        {

        }
    }
}