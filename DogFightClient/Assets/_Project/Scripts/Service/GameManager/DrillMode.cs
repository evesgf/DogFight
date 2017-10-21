using LarkFramework.Tick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class DrillMode
    {
        private uint m_mainPlayerId = 1;
        private int m_frameIndex = 0;

        public event Action onMainPlayerDie;
        public event Action onGameEnd;

        private GameContext m_context;

        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="param"></param>
        public void Start(GameParam param)
        {
            //初始化游戏数据
            GameManager.Instance.CreateGame(param);
            GameManager.Instance.onPlayerDie += OnPlayerDie;
            m_context = GameManager.Instance.Context;

            //初始化玩家数据
            var playerData = new PlayerData();
            playerData.id = m_mainPlayerId;
            playerData.userId = UserManager.Instance.MainUserData.id;

            //初始化飞船数据
            playerData.shipData.id = 0;

            //注册玩家数据
            GameManager.Instance.RegPlayerData(playerData);

            //初始化输入

            //加入循环
            TickManager.Instance.m_TickComponent.onFixedUpdate+= FixedUpdate;

            //初始化摄像机
        }

        #region 玩家相关
        /// <summary>
        /// 创建玩家
        /// </summary>
        public void CreatePlayer()
        {

        }

        /// <summary>
        /// 重生玩家
        /// </summary>
        public void RebornPlayer()
        {
            CreatePlayer();
        }

        /// <summary>
        /// 当玩家死亡时，进行处理
        /// </summary>
        /// <param name="playerId"></param>
        private void OnPlayerDie(uint playerId)
        {

        }
        #endregion

        #region 逻辑循环相关
        /// <summary>
        /// 驱动游戏逻辑循环
        /// </summary>
        private void FixedUpdate(float elapseSeconds, float realElapseSeconds)
        {
            m_frameIndex++;
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        private void ExitGame()
        {
            //移除循环
            TickManager.Instance.m_TickComponent.onFixedUpdate -= FixedUpdate;

            onGameEnd = null;
            onMainPlayerDie = null;
            m_context = null;
        }
        #endregion
    }
}
