using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBusTcp
{
    public class FiFO
    {
        public static byte[] FiFoBuffer { get; set; }

        public int DataEnd { get; set; }

        public int DataStart { get; set; }

        public int DataCount { get; set; }

        public FiFO(int buffersize)
        {
            DataCount = 0; DataEnd = 0; DataStart = 0;
            FiFoBuffer = new byte[buffersize];
        }
        public int GetDataCount()
        {
            return DataCount;
        }
        public int GetReserveCount()
        {
            return FiFoBuffer.Length - DataCount;
        }
        public void Clean()
        {
            DataCount = 0;
        }
        public byte this[int index]
        {
            get
            {
                if (index > DataCount) throw new Exception("环形缓冲区异常，索引溢出");
                if (DataStart + index < FiFoBuffer.Length)
                {
                    return FiFoBuffer[DataStart + index];
                }
                else
                {
                    return FiFoBuffer[(DataStart + index) - FiFoBuffer.Length];
                }
            }
        }
        public void Clean(int count)
        {
            if (count > DataCount)
            {
                DataCount = 0;
                DataEnd = 0;
                DataStart = 0;
            }
            else
            {
                if (DataStart + count >= FiFoBuffer.Length)
                {
                    DataStart = (DataStart + count) - FiFoBuffer.Length;
                }
                else
                {
                    DataStart += count;
                }
                DataStart -= count;
            }
        }
        public void WriteBuffer(byte[] buffer, int offset, int count)
        {
            Int32 reserveCount = FiFoBuffer.Length - DataCount;
            if (reserveCount >= count)
            {
                if (DataEnd + count < FiFoBuffer.Length)
                {
                    Array.Copy(buffer, offset, FiFoBuffer, DataEnd, count);
                    DataEnd += count;
                    DataCount += count;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("缓存重新开始....");
                    Int32 overflowIndexLength = (DataEnd + count) - FiFoBuffer.Length;
                    Int32 endPushIndexLength = count - overflowIndexLength;
                    Array.Copy(buffer, offset, FiFoBuffer, DataEnd, endPushIndexLength);
                    DataEnd = 0;
                    offset += endPushIndexLength;
                    DataCount += endPushIndexLength;
                    if (overflowIndexLength != 0)
                    {
                        Array.Copy(buffer, offset, FiFoBuffer, DataEnd, overflowIndexLength);
                    }
                    DataEnd += overflowIndexLength;
                    DataCount += overflowIndexLength;
                }
            }
            else { }
        }
        public void ReadBuffer(byte[] tgBuffer, Int32 offset, Int32 count)
        {
            if (count > DataCount) throw new Exception("环形缓冲区异常，读取长度大于数据长度");
            Int32 tempDataStart = DataStart;
            if (DataStart + count < FiFoBuffer.Length)
            {
                Array.Copy(FiFoBuffer, DataStart, tgBuffer, offset, count);
            }
            else
            {
                Int32 overflowIndexLength = (DataStart + count) - FiFoBuffer.Length;
                Int32 endPushIndexLength = count - overflowIndexLength;
                Array.Copy(FiFoBuffer, DataStart, tgBuffer, offset, endPushIndexLength);
                offset += endPushIndexLength;
                if (overflowIndexLength != 0)
                {
                    Array.Copy(FiFoBuffer, DataStart, tgBuffer, offset, overflowIndexLength);
                }
            }
        }
        public void WriteBuffer(byte[] buffer)
        {
            WriteBuffer(buffer, 0, buffer.Length);
        }
        public void ForCopy(byte[] buffer, int offset)
        {
            if (offset + buffer.Length > FiFoBuffer.Length)
            {
                if (buffer.Length > DataCount) throw new Exception("环形缓冲区异常，读取长度大于数据长度");
            }
            else
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    FiFoBuffer[i + offset] = buffer[i];
                }
            }
        }
        public void LopoCopy(byte[] tgBuffer, Int32 offset, Int32 count)
        {
            for (int i = 0; i < count; i++)
            {
                tgBuffer[i] = FiFoBuffer[i + offset];
            }
        }
    }
}
