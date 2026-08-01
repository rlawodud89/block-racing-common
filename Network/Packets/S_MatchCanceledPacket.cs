using block_racing_common.Game.Enums;
using System;
using System.Collections.Generic;

namespace block_racing_common.Network.Packets
{
    public class S_MatchCanceledPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_MatchCanceled;

        public void Read(PacketReader reader)
        {
            
        }

        public void Write(PacketWriter writer)
        {
            
        }
    }
}
