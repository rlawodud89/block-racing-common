using block_racing_common.Game.Enums;
using System;
using System.Collections.Generic;

namespace block_racing_common.Network.Packets
{
    public class S_GameCanceledPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_GameCanceled;

        public void Read(PacketReader reader)
        {
            
        }

        public void Write(PacketWriter writer)
        {
            
        }
    }
}
