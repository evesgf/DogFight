using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    /// <summary>
    /// 单局中飞船的数据，这里要与飞船的配置数据区分
    /// 如果我们要做飞船的成长系统，则需要区分飞船的配置数据和强化后的数据
    /// </summary>
    [ProtoContract]
    public class ShipData
    {
        /// <summary>
        /// 飞船的ID，表示这是一条什么样的飞船，可以通过这个ID 找到飞船的资源和配置
        /// 为什么不直接使用飞船的配置数据？
        /// 因为，有可能不同的玩家使用了同一条飞船，通过不同的强化后，这条飞船的实际参数会不同
        /// 比如初始长度不同等
        /// </summary>
        [ProtoMember(1)] public int id;

        /// <summary>
        /// 蛇的名号
        /// </summary>
        [ProtoMember(2)] public string name = "";
    }
}
