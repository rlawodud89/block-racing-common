using System;
using System.Buffers.Binary;
using System.Text;

namespace block_racing_common.Network
{
    public class PacketWriter
    {
        private byte[] _buffer;
        private int _position;

        public PacketWriter(ushort packetId, int initialCapacity = 1024)
        {
            _buffer = new byte[initialCapacity];

            // Length placeholder
            _position += 2;

            // PacketId
            Write(packetId);
        }

        public void Write(bool value)
        {
            EnsureCapacity(1);

            _buffer[_position++] = value ? (byte)1 : (byte)0;
        }

        public void Write(byte value)
        {
            EnsureCapacity(1);

            _buffer[_position++] = value;
        }

        public void Write(ushort value)
        {
            EnsureCapacity(2);

            BinaryPrimitives.WriteUInt16LittleEndian(
                _buffer.AsSpan(_position, 2),
                value);

            _position += 2;
        }

        public void Write(int value)
        {
            EnsureCapacity(4);

            BinaryPrimitives.WriteInt32LittleEndian(
                _buffer.AsSpan(_position, 4),
                value);

            _position += 4;
        }

        public void Write(long value)
        {
            EnsureCapacity(8);

            BinaryPrimitives.WriteInt64LittleEndian(
                _buffer.AsSpan(_position, 8),
                value);

            _position += 8;
        }

        public void Write(float value)
        {
            EnsureCapacity(4);

            BinaryPrimitives.WriteInt32LittleEndian(
                _buffer.AsSpan(_position, 4),
                BitConverter.SingleToInt32Bits(value));

            _position += 4;
        }

        public void Write(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            Write((ushort)bytes.Length);

            EnsureCapacity(bytes.Length);

            bytes.CopyTo(
                _buffer,
                _position);

            _position += bytes.Length;
        }

        public byte[] ToArray()
        {
            ushort length = checked((ushort)_position);

            BinaryPrimitives.WriteUInt16LittleEndian(
                _buffer.AsSpan(0, 2),
                length);

            byte[] result = new byte[_position];

            Buffer.BlockCopy(
                _buffer,
                0,
                result,
                0,
                _position);

            return result;
        }

        private void EnsureCapacity(int additionalBytes)
        {
            int required = _position + additionalBytes;

            if (required <= _buffer.Length)
                return;

            int newSize = Math.Max(
                _buffer.Length * 2,
                required);

            Array.Resize(
                ref _buffer,
                newSize);
        }
    }
}