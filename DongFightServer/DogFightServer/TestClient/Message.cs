using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestClient
{
    class Message
    {
        public static byte[] GetBytes(string data)
        {
            //数据内容
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataLength = dataBytes.Length;
            //数据长度
            byte[] lengthBytes = BitConverter.GetBytes(dataLength);
            //最终返回消息
            byte[] returnBytes = lengthBytes.Concat(dataBytes).ToArray();
            return returnBytes;
        }
    }
}
