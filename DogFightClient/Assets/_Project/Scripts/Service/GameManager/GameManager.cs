using LarkFramework.Module;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    /// <summary>
    /// 核心对战管理
    /// </summary>
    public class GameManager : ServiceModule<GameManager>
    {
        private string LOG_TAG = "GameManager";

        private bool m_isRunning;

        //游戏上下文
        private GameContext m_Context;

        //游戏地图

        //玩家管理

        //玩家死亡事件
        public event PlayerDieEvent onPlayerDie;

        //======================================================================
        public bool IsRunning { get { return m_isRunning; } }
        public GameContext Context { get { return m_Context; } }
        public GameMode GameMode { get { return m_Context.param.mode; } }

        //======================================================================
        public void Init()
        {

        }

        //======================================================================
        public void CreateGame(GameParam param)
        {
            if (m_isRunning)
            {
                Debuger.LogError(LOG_TAG, "Create() Game Is Runing Already!");
                return;
            }

            //创建上下文，保存战斗全局参数

            //创建地图

            //初始化实体工厂

            //初始化摄像机
        }

        //======================================================================
        public void InputVKey(int vkey, float arg, uint playerId)
        {

        }

        //======================================================================
        /// <summary>
        /// 注册玩家数据
        /// </summary>
        public void RegPlayerData(PlayerData playerData)
        {

        }

        //======================================================================
        /// <summary>
        /// 创建玩家
        /// </summary>
        /// <param name="playerId"></param>
        internal void CreatePlayer(uint playerId)
        {

        }
    }
}
