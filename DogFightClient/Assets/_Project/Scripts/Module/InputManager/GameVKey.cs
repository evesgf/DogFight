using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    /// <summary>
    /// 定义游戏单局中可能的玩家操作
    /// </summary>
    public static class GameVKey
    {
        /// <summary>
        /// X方向移动
        /// </summary>
        public const int MoveX = 11;

        /// <summary>
        /// Y方向移动
        /// </summary>
        public const int MoveY = 12;

        /// <summary>
        /// 技能高槽1
        /// </summary>
        public const int Skill_H1 = 1;

        /// <summary>
        /// 在单局中创建一个玩家
        /// </summary>
        public const int CreatePlayer = 20;
    }
}
