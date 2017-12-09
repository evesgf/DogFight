using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    /// <summary>
    /// 游戏模式
    /// </summary>
    public enum GameMode
    {
        /// <summary>
        /// 训练模式
        /// </summary>
        DrillMode = 0,

        /// <summary>
        /// 常规战
        /// </summary>
        NormalMode=1,

        /// <summary>
        /// 地面战
        /// </summary>
        GroundMode=2,

        /// <summary>
        /// 太空战
        /// </summary>
        SpaceMode=3,

        /// <summary>
        /// 指挥战
        /// </summary>
        CommondMode=4
    }
}
