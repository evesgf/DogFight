using LarkFramework.Tick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class DrillGameMode
    {
        private int m_MainPlayerId = 1;
        private int m_frameindex = 0;

        public event Action onMainPlayerDie;
        public event Action onGameEnd;
        private GameContext m_context;

        public void Start(GameParam param)
        {
            GameManager.Instance.CreateGame(param);
            GameManager.Instance.onPlayerDie += OnPlayerDie;
            m_context = GameManager.Instance.Context;

            PlayerData pd = new PlayerData();
            pd.id = m_MainPlayerId;
            pd.userId = 123456;
            pd.shipData.id = 1;

            GameManager.Instance.RegPlayerData(pd);

            InputComponent.Instance.ShowInputPanel();
            InputComponent.OnVkey += OnVKey;
        }

        public void Stop()
        {
            GameManager.Instance.ReleaseGame();

            onGameEnd = null;
            onMainPlayerDie = null;
            m_context = null;
        }

        public void CreatePlayer()
        {
            GameManager.Instance.InputVKey(GameVKey.CreatePlayer, 0, m_MainPlayerId);
        }

        /// <summary>
        /// 收到来自GameInput的输入
        /// </summary>
        /// <param name="vkey"></param>
        /// <param name="arg"></param>
        private void OnVKey(int vkey, float arg)
        {
            GameManager.Instance.InputVKey(vkey, arg, m_MainPlayerId);
        }

        public void FixedUpdate(float elapseSeconds, float realElapseSeconds)
        {
            m_frameindex++;
            GameManager.Instance.EnterFrame(m_frameindex);

        }

        private void OnPlayerDie(int playerId)
        {
            if (m_MainPlayerId == playerId)
            {
                if (onMainPlayerDie != null)
                {
                    onMainPlayerDie();
                }
                else
                {
                    this.LogError("OnPlayerDie() onMainPlayerDie == null!");
                }
            }
        }
    }
}
