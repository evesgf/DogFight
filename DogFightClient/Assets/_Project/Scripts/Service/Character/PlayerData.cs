using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    /// <summary>
    /// 单局中玩家的数据
    /// </summary>
    [ProtoContract]
    public class PlayerData
    {
        /// <summary>
        /// 这个ID 是单局中分配的ID，只在单局中有效
        /// </summary>
        [ProtoMember(1)] public int id;

        /// <summary>
        /// 这个玩家对应的用户的ID 
        /// </summary>
        [ProtoMember(2)] public int userId;

        /// <summary>
        /// 玩家的名字
        /// </summary>
        [ProtoMember(3)] public string name;

        /// <summary>
        /// 这个玩家在单局中所使用的飞船的数据
        /// </summary>
        [ProtoMember(4)] public ShipData shipData = new ShipData();

        /// <summary>
        /// 玩家的组队ID，如果是单人，则等于id
        /// </summary>
        [ProtoMember(5)] public int teamId = 0;

        /// <summary>
        /// 玩家在单局中的得分
        /// </summary>
        [ProtoMember(6)] public int score = 0;

        /// <summary>
        /// 如果这个玩家挂机，或者是AI玩家的话，其AI的ID，如果0则是不使用AI
        /// </summary>
        [ProtoMember(7)] public int ai = 0;
    }
}
