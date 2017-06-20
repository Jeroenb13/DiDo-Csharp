using System;
using System.Text;

namespace DiDoCommon.Network
{
    /// <summary>
    /// Simple HeapByteBuf implementation
    /// Code derived from java Netty and C# DotNetty
    /// 
    /// https://github.com/netty/netty/tree/4.1/buffer
    /// https://github.com/Azure/DotNetty/tree/dev/src/DotNetty.Buffers
    /// 
    /// Not using DotNetty.Buffers directly, because it's incompatible with UWP
    /// </summary>
    /// <author>Jeffrey Kog</author>
    public class HeapByteBuf
    {
        byte[] array;
        public int ReaderIndex { get; set; }
        public int WriterIndex { get; set; }
        int markedReaderIndex;
        int markedWriterIndex;

        public int MaxCapacity { get;}

        public int Capacity {
            get
            {
                return this.array.Length;
            }
        }

        /// <summary>
        /// Creates a new heap buffer with a newly allocated byte array.
        /// </summary>
        /// <param name="initialCapacity">the initial capacity of the underlying byte array</param>
        /// <param name="maxCapacity">the max capacity of the underlying byte array</param>
        public HeapByteBuf(int initialCapacity, int maxCapacity)
            : this(new byte[initialCapacity], 0, 0, maxCapacity)
        {
        }
        
        /// <summary>
        /// Creates a new heap buffer with an existing byte array.
        /// </summary>
        /// <param name="initialArray">the initial underlying byte array</param>
        /// <param name="maxCapacity">the max capacity of the underlying byte array</param>
        public HeapByteBuf(byte[] initialArray, int maxCapacity)
            : this(initialArray, 0, initialArray.Length, maxCapacity)
        {
        }
        
        /// <summary>
        /// Internal constructor to create a new heap buffer
        /// </summary>
        /// <param name="initialArray">the initial underlying byte array</param>
        /// <param name="readerIndex">The reader index, bytes will be read from this index</param>
        /// <param name="writerIndex">The writer index, bytes will be written to this index</param>
        /// <param name="maxCapacity">the max capacity of the underlying byte array</param>
        private HeapByteBuf(byte[] initialArray, int readerIndex, int writerIndex, int maxCapacity)
        {
            if(initialArray == null)
            {
                throw new ArgumentNullException("initialArray");
            }

            if(initialArray.Length > maxCapacity)
            {
                throw new ArgumentOutOfRangeException("The initialArray should be smaller than maxCapacity");
            }

            this.MaxCapacity = maxCapacity;
            this.array = initialArray;
            this.ReaderIndex = readerIndex;
            this.WriterIndex = writerIndex;
        }

        public HeapByteBuf AdjustCapacity(int newCapacity)
        {
            this.CheckNewCapacity(newCapacity);

            int oldCapacity = this.array.Length;
            if (newCapacity > oldCapacity)
            {
                var newArray = new byte[newCapacity];
                Array.Copy(this.array, 0, newArray, 0, this.array.Length);
                this.array = newArray;
            }
            else if (newCapacity < oldCapacity)
            {
                var newArray = new byte[newCapacity];
                int readerIndex = this.ReaderIndex;
                if (readerIndex < newCapacity)
                {
                    int writerIndex = this.WriterIndex;
                    if (writerIndex > newCapacity)
                    {
                        this.WriterIndex = (writerIndex = newCapacity);
                    }
                    Array.Copy(this.array, readerIndex, newArray, readerIndex, writerIndex - readerIndex);
                }
                else
                {
                    this.ReaderIndex = newCapacity;
                    this.WriterIndex = newCapacity;
                }
                this.array = newArray;
            }

            return this;
        }

        protected void CheckNewCapacity(int newCapacity)
        {
            if (newCapacity < 0 || newCapacity > this.MaxCapacity)
            {
                throw new ArgumentOutOfRangeException(nameof(newCapacity), $"newCapacity: {newCapacity} (expected: 0-{this.MaxCapacity})");
            }
        }

        public HeapByteBuf SetZero(int index, int length)
        {
            this.CheckIndex(index, length);
            System.Array.Clear(this.array, index, length);
            return this;
        }

        public byte GetByte(int index)
        {
            return this._GetByte(index);
        }

        protected byte _GetByte(int index) => this.array[index];

        public short GetShort(int index)
        {
            return this._GetShort(index);
        }

        protected short _GetShort(int index) => unchecked((short)(this.array[index] << 8 | this.array[index + 1]));

        public int GetInt(int index)
        {
            return this._GetInt(index);
        }

        protected int _GetInt(int index)
        {
            return unchecked(this.array[index] << 24 |
                this.array[index + 1] << 16 |
                this.array[index + 2] << 8 |
                this.array[index + 3]);
        }

        public long GetLong(int index)
        {
            return this._GetLong(index);
        }

        public int GetMedium(int index)
        {
            return this._GetMedium(index);
        }

        protected int _GetMedium(int index)
        {
            return (sbyte)this.array[index] << 16 |
                    this.array[index + 1] << 8 |
                    this.array[index + 2];
        }

        protected long _GetLong(int index)
        {
            unchecked
            {
                int i1 = this.array[index] << 24 |
                    this.array[index + 1] << 16 |
                    this.array[index + 2] << 8 |
                    this.array[index + 3];
                int i2 = this.array[index + 4] << 24 |
                    this.array[index + 5] << 16 |
                    this.array[index + 6] << 8 |
                    this.array[index + 7];
                return (uint)i2 | ((long)i1 << 32);
            }
        }

        public string GetString(int index)
        {
            ushort length = (ushort)this.GetShort(index);
            byte[] data = new byte[length];
            Array.Copy(this.array, index + 2, data, 0, length);
            return Encoding.UTF8.GetString(data);
        }

        public HeapByteBuf SetByte(int index, int value)
        {
            this._SetByte(index, value);
            return this;
        }

        protected void _SetByte(int index, int value) => this.array[index] = (byte)value;

        public HeapByteBuf SetShort(int index, int value)
        {
            this._SetShort(index, value);
            return this;
        }

        protected void _SetShort(int index, int value)
        {
            unchecked
            {
                this.array[index] = (byte)((ushort)value >> 8);
                this.array[index + 1] = (byte)value;
            }
        }

        public HeapByteBuf SetMedium(int index, int value)
        {
            this._SetMedium(index, value);
            return this;
        }

        protected void _SetMedium(int index, int value)
        {
            unchecked
            {
                uint unsignedValue = (uint)value;
                this.array[index] = (byte)(unsignedValue >> 16);
                this.array[index + 1] = (byte)(unsignedValue >> 8);
                this.array[index + 2] = (byte)value;
            }
        }

        public HeapByteBuf SetInt(int index, int value)
        {
            this._SetInt(index, value);
            return this;
        }

        protected void _SetInt(int index, int value)
        {
            unchecked
            {
                uint unsignedValue = (uint)value;
                this.array[index] = (byte)(unsignedValue >> 24);
                this.array[index + 1] = (byte)(unsignedValue >> 16);
                this.array[index + 2] = (byte)(unsignedValue >> 8);
                this.array[index + 3] = (byte)value;
            }
        }

        public HeapByteBuf SetLong(int index, long value)
        {
            this._SetLong(index, value);
            return this;
        }

        protected void _SetLong(int index, long value)
        {
            unchecked
            {
                ulong unsignedValue = (ulong)value;
                this.array[index] = (byte)(unsignedValue >> 56);
                this.array[index + 1] = (byte)(unsignedValue >> 48);
                this.array[index + 2] = (byte)(unsignedValue >> 40);
                this.array[index + 3] = (byte)(unsignedValue >> 32);
                this.array[index + 4] = (byte)(unsignedValue >> 24);
                this.array[index + 5] = (byte)(unsignedValue >> 16);
                this.array[index + 6] = (byte)(unsignedValue >> 8);
                this.array[index + 7] = (byte)value;
            }
        }

        public HeapByteBuf SetString(int index, string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);

            this.SetShort(index, data.Length);
            this.SetBytes(index + 2, data);
            return this;
        }

        protected void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Capacity)
            {
                throw new IndexOutOfRangeException($"index: {index} (expected: range(0, {this.Capacity})");
            }
        }

        protected void CheckIndex(int index, int fieldLength)
        {
            if (fieldLength < 0)
            {
                throw new IndexOutOfRangeException($"length: {fieldLength} (expected: >= 0)");
            }

            if (index < 0 || index > this.Capacity - fieldLength)
            {
                throw new IndexOutOfRangeException($"index: {index}, length: {fieldLength} (expected: range(0, {this.Capacity})");
            }
        }

        public virtual bool ReadBoolean() => this.ReadByte() != 0;

        public virtual byte ReadByte()
        {
            this.CheckReadableBytes(1);
            int i = this.ReaderIndex;
            byte b = this.GetByte(i);
            this.ReaderIndex = i + 1;
            return b;
        }

        public virtual short ReadShort()
        {
            this.CheckReadableBytes(2);
            short v = this._GetShort(this.ReaderIndex);
            this.ReaderIndex += 2;
            return v;
        }

        public virtual ushort ReadUnsignedShort()
        {
            unchecked
            {
                return (ushort)(this.ReadShort());
            }
        }

        public virtual int ReadInt()
        {
            this.CheckReadableBytes(4);
            int v = this._GetInt(this.ReaderIndex);
            this.ReaderIndex += 4;
            return v;
        }

        public virtual int ReadMedium()
        {
            this.CheckReadableBytes(3);
            int v = this._GetMedium(this.ReaderIndex);
            this.ReaderIndex += 3;
            return v;
        }

        public virtual uint ReadUnsignedInt()
        {
            unchecked
            {
                return (uint)(this.ReadInt());
            }
        }

        public virtual long ReadLong()
        {
            this.CheckReadableBytes(8);
            long v = this._GetLong(this.ReaderIndex);
            this.ReaderIndex += 8;
            return v;
        }

        public virtual string ReadString()
        {
            this.CheckReadableBytes(2);
            ushort length = (ushort)this.GetShort(this.ReaderIndex);
            this.CheckReadableBytes(2 + length);
            byte[] data = new byte[length];
            Array.Copy(this.array, this.ReaderIndex + 2, data, 0, length);
            string ret = Encoding.UTF8.GetString(data);
            this.ReaderIndex += 2 + length;
            return ret;
        }

        public virtual char ReadChar() => (char)this.ReadShort();

        public virtual double ReadDouble() => BitConverter.Int64BitsToDouble(this.ReadLong());
        
        public virtual HeapByteBuf SkipBytes(int length)
        {
            this.CheckReadableBytes(length);
            this.ReaderIndex += length;
            return this;
        }

        public virtual HeapByteBuf WriteBoolean(bool value)
        {
            this.WriteByte(value ? 1 : 0);
            return this;
        }

        public virtual HeapByteBuf WriteByte(int value)
        {
            
            this.EnsureWritable(1);
            this.SetByte(this.WriterIndex, value);
            this.WriterIndex += 1;
            return this;
        }

        public virtual HeapByteBuf WriteShort(int value)
        {
            
            this.EnsureWritable(2);
            this._SetShort(this.WriterIndex, value);
            this.WriterIndex += 2;
            return this;
        }

        public HeapByteBuf WriteUnsignedShort(ushort value)
        {
            unchecked
            {
                this.WriteShort((short)value);
            }
            return this;
        }

        public virtual HeapByteBuf WriteMedium(int value)
        {
            
            this.EnsureWritable(3);
            this._SetMedium(this.WriterIndex, value);
            this.WriterIndex += 3;
            return this;
        }

        public virtual HeapByteBuf WriteInt(int value)
        {
            
            this.EnsureWritable(4);
            this._SetInt(this.WriterIndex, value);
            this.WriterIndex += 4;
            return this;
        }

        public HeapByteBuf WriteUnsignedInt(uint value)
        {
            unchecked
            {
                this.WriteInt((int)value);
            }
            return this;
        }

        public virtual HeapByteBuf WriteLong(long value)
        {
            
            this.EnsureWritable(8);
            this._SetLong(this.WriterIndex, value);
            this.WriterIndex += 8;
            return this;
        }

        public virtual HeapByteBuf WriteChar(char value)
        {
            this.WriteShort(value);
            return this;
        }

        public virtual HeapByteBuf WriteDouble(double value)
        {
            this.WriteLong(BitConverter.DoubleToInt64Bits(value));
            return this;
        }

        public virtual HeapByteBuf WriteBytes(byte[] src)
        {
            this.WriteBytes(src, 0, src.Length);
            return this;
        }

        public virtual HeapByteBuf WriteBytes(byte[] src, int srcIndex, int length)
        {
            
            this.EnsureWritable(length);
            this.SetBytes(this.WriterIndex, src, srcIndex, length);
            this.WriterIndex += length;
            return this;
        }

        public virtual HeapByteBuf WriteZero(int length)
        {
            
            this.EnsureWritable(length);
            this.SetZero(this.WriterIndex, length);
            this.WriterIndex += length;
            return this;
        }

        public virtual HeapByteBuf WriteString(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);
            this.EnsureWritable(2 + data.Length);
            this.WriteUnsignedShort((ushort)data.Length);
            this.WriteBytes(data);
            this.WriterIndex += 2 + data.Length;
            return this;
        }

        /// <summary>
        ///     Throws a <see cref="IndexOutOfRangeException" /> if the current <see cref="ReadableBytes" /> of this buffer
        ///     is less than <paramref name="minimumReadableBytes" />.
        /// </summary>
        protected void CheckReadableBytes(int minimumReadableBytes)
        {
            if (minimumReadableBytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumReadableBytes), $"minimumReadableBytes: {minimumReadableBytes} (expected: >= 0)");
            }

            if (this.ReaderIndex > this.WriterIndex - minimumReadableBytes)
            {
                throw new IndexOutOfRangeException($"readerIndex({this.ReaderIndex}) + length({minimumReadableBytes}) exceeds writerIndex({this.WriterIndex}): {this}");
            }
        }

        public virtual HeapByteBuf EnsureWritable(int minWritableBytes)
        {
            if (minWritableBytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minWritableBytes),
                    "expected minWritableBytes to be greater than zero");
            }

            if (minWritableBytes <= this.WritableBytes)
            {
                return this;
            }

            if (minWritableBytes > this.MaxCapacity - this.WriterIndex)
            {
                throw new IndexOutOfRangeException($"writerIndex({this.WriterIndex}) + minWritableBytes({minWritableBytes}) exceeds maxCapacity({this.MaxCapacity}): {this}");
            }

            //Normalize the current capacity to the power of 2
            int newCapacity = this.CalculateNewCapacity(this.WriterIndex + minWritableBytes);

            //Adjust to the new capacity
            this.AdjustCapacity(newCapacity);
            return this;
        }

        public int EnsureWritable(int minWritableBytes, bool force)
        {
            if(minWritableBytes < 0)
            {
                throw new ArgumentOutOfRangeException("minWritableBytes should be >= 0");
            }

            if (minWritableBytes <= this.WritableBytes)
            {
                return 0;
            }

            if (minWritableBytes > this.MaxCapacity - this.WriterIndex)
            {
                if (force)
                {
                    if (this.Capacity == this.MaxCapacity)
                    {
                        return 1;
                    }

                    this.AdjustCapacity(this.MaxCapacity);
                    return 3;
                }
            }

            // Normalize the current capacity to the power of 2.
            int newCapacity = this.CalculateNewCapacity(this.WriterIndex + minWritableBytes);

            // Adjust to the new capacity.
            this.AdjustCapacity(newCapacity);
            return 2;
        }

        public virtual int ReadableBytes => this.WriterIndex - this.ReaderIndex;

        public virtual int WritableBytes => this.Capacity - this.WriterIndex;

        public virtual int MaxWritableBytes => this.MaxCapacity - this.WriterIndex;

        public bool IsReadable() => this.IsReadable(1);

        public bool IsReadable(int size) => this.ReadableBytes >= size;

        public bool IsWritable() => this.IsWritable(1);

        public bool IsWritable(int size) => this.WritableBytes >= size;

        int CalculateNewCapacity(int minNewCapacity)
        {
            int maxCapacity = this.MaxCapacity;
            const int Threshold = 4 * 1024 * 1024; // 4 MiB page
            int newCapacity;
            if (minNewCapacity == Threshold)
            {
                return Threshold;
            }

            // If over threshold, do not double but just increase by threshold.
            if (minNewCapacity > Threshold)
            {
                newCapacity = minNewCapacity - (minNewCapacity % Threshold);
                return Math.Min(maxCapacity, newCapacity + Threshold);
            }

            // Not over threshold. Double up to 4 MiB, starting from 64.
            newCapacity = 64;
            while (newCapacity < minNewCapacity)
            {
                newCapacity <<= 1;
            }

            return Math.Min(newCapacity, maxCapacity);
        }

        public virtual HeapByteBuf SetBytes(int index, byte[] src)
        {
            this.SetBytes(index, src, 0, src.Length);
            return this;
        }

        public HeapByteBuf SetBytes(int index, byte[] src, int srcIndex, int length)
        {
            this.CheckSrcIndex(index, length, srcIndex, src.Length);
            System.Array.Copy(src, srcIndex, this.array, index, length);
            return this;
        }

        protected void CheckSrcIndex(int index, int length, int srcIndex, int srcCapacity)
        {
            this.CheckIndex(index, length);
            if (srcIndex < 0 || srcIndex > srcCapacity - length)
            {
                throw new IndexOutOfRangeException($"srcIndex: {srcIndex}, length: {length} (expected: range(0, {srcCapacity}))");
            }
        }
    }
}
