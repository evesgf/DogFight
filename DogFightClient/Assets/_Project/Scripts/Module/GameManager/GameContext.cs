using LarkFramework.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class GameContext
    {
        /// <summary>
        /// 游戏的启动参数
        /// </summary>
        public GameParam param = null;

        /// <summary>
        /// 随机数生成器
        /// </summary>
        public SGFRandom random = new SGFRandom();

        /// <summary>
        /// 当前是第几帧
        /// </summary>
        public int currentFrameIndex = 0;
    }
}
