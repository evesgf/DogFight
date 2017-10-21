using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    /// <summary>
    /// 单局游戏的上下文
    /// 用来保存单局中所有逻辑都关心的数据
    /// </summary>
    public class GameContext
    {
        public GameParam param = null;

        /// <summary>
        /// 当前为游戏开始第几帧
        /// </summary>
        public int currentFrameIndex = 0;

    }
}
