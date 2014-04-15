using System;

namespace BEncoding.NET {
    public static class Message {

        static public int Write(byte[] buffer, int offset, byte value) {
            buffer[offset] = value;
            return 1;
        }

        static public int Write(byte[] dest, int destOffset, byte[] src, int srcOffset, int count) {
            Buffer.BlockCopy(src, srcOffset, dest, destOffset, count);
            return count;
        }

        static public int Write(byte[] buffer, int offset, short value) {
            offset += Write(buffer, offset, (byte) (value >> 8));
            offset += Write(buffer, offset, (byte) value);
            return 2;
        }

        static public int Write(byte[] buffer, int offset, int value) {
            offset += Write(buffer, offset, (byte) (value >> 24));
            offset += Write(buffer, offset, (byte) (value >> 16));
            offset += Write(buffer, offset, (byte) (value >> 8));
            offset += Write(buffer, offset, (byte) (value));
            return 4;
        }

        static public int Write(byte[] buffer, int offset, uint value) {
            return Write(buffer, offset, (int) value);
        }

        static public int Write(byte[] buffer, int offset, long value) {
            offset += Write(buffer, offset, (int) (value >> 32));
            offset += Write(buffer, offset, (int) value);
            return 8;
        }

        static public int Write(byte[] buffer, int offset, byte[] value) {
            return Write(buffer, offset, value, 0, value.Length);
        }

        static public int WriteAscii(byte[] buffer, int offset, string text) {
            for(int i = 0; i < text.Length; i++)
                Write(buffer, offset + i, (byte) text[i]);
            return text.Length;
        }
    }
}
