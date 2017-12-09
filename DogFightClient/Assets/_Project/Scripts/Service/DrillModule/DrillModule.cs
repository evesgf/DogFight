using LarkFramework.Module;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class DrillModule : BusinessModule
    {
        public DrillGameMode m_game;

        public override void Show()
        {
            base.Show();
            Debuger.Log("Show " + Name);
            StartGame(GameMode.DrillMode);
        }

        private void StartGame(GameMode mode)
        {
            GameParam param = new GameParam();
            param.mode = mode;
            param.limitedTime = 10;

            m_game = new DrillGameMode();
            m_game.Start(param);
            m_game.onGameEnd += () => { StopGame(); };

            //打开UI
        }

        private void StopGame()
        {
            if (m_game != null)
            {
                m_game.Stop();
                m_game = null;
            }
        }

        public DrillGameMode GetCurrentGame()
        {
            return m_game;
        }
    }
}
