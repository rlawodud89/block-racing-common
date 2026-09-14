using System;
using System.Collections.Generic;
using System.IO;

namespace block_racing_common.Network
{
    public class ReceiveBuffer
    {
        private readonly List<byte> _buffer = new();

        private const int MaxPacketSize = 1024;

        public void Append(byte[] data, int length)
        {
            for (int i = 0; i < length; i++)
                _buffer.Add(data[i]);
        }

        public bool TryReadPacket(out byte[] packet)
        {
            packet = Array.Empty<byte>();

            if (_buffer.Count < PacketHeader.Size)
                return false;

            ushort packetLength =
                (ushort)(_buffer[0] | (_buffer[1] << 8));

            if (packetLength < PacketHeader.Size ||
                packetLength > MaxPacketSize)
            {
                throw new InvalidDataException(
                    $"Invalid packet length: {packetLength}");
            }

            if (_buffer.Count < packetLength)
                return false;

            packet = new byte[packetLength];

            for (int i = 0; i < packetLength; i++)
                packet[i] = _buffer[i];

            _buffer.RemoveRange(0, packetLength);

            return true;
        }
    }
}