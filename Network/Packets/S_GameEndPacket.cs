using System;
using System.Collections.Generic;
using block_racing_common.Game.Enums;

namespace block_racing_common.Network.Packets
{
    public class S_GameEndPacket : IPacket
    {
        public PacketId PacketId => PacketId.S_GameEnd;

        public GameResultType Result { get; set; }


        public void Read(PacketReader reader)
        {
            Result = (GameResultType)reader.ReadByte();
        }

        public void Write(PacketWriter writer)
        {
            writer.Write((byte)Result);
        }
    }
}