using System;
using System.Collections.Generic;
using System.Text;

namespace TestServer
{
    class Message
    {
        //缓存数据
        private byte[] data = new byte[1024];
        public byte[] Data { get { return data; } }

        //存储标志位
        private int startIndex = 0;
        public int StartIndex { get { return startIndex; } }

        /// <summary>
        /// 剩余数据空间
        /// </summary>
        public int RemainSize { get { return data.Length - startIndex; } }

        /// <summary>
        /// 新增数据，增加索引
        /// </summary>
        /// <param name="count"></param>
        public void AddCount(int count)
        {
            startIndex += count;
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        public void ReadMessage()
        {
            while (true)
            {
                //这里的4是长度标志位的int32字节长度
                if (startIndex <= 4) return;

                int count = BitConverter.ToInt32(data, 0);

                if ((startIndex - 4) >= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("解析好一条数据:" + s+"["+ count + "]");
                    //解析好的数据放入缓存前面
                    Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                    startIndex -= (count + 4);
                }
                else
                {
                    break;      //数据不完整
                }
            }
        }
    }
}
