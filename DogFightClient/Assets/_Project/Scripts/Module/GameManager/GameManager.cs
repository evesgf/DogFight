using LarkFramework.Entity;
using LarkFramework.Entity.Example;
using LarkFramework.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class GameManager: ServiceModule<GameManager>
    {
        private string LOG_TAG = "GameManager";

        private bool m_isRunning;

        /// <summary>
        /// 游戏的上下文
        /// </summary>
        private GameContext m_context;

        private GameMap m_map;

        //玩家管理，敌人管理
        private List<Player> m_listPlayer = new List<Player>();
        private List<Npc> m_listNpc = new List<Npc>();
        //玩家单局Id与玩家数据绑定
        private DictionaryEx<int, PlayerData> m_mapPlayerData = new DictionaryEx<int, PlayerData>();

        public event PlayerDieEvent onPlayerDie;

        //======================================================================
        public bool IsRunning { get { return m_isRunning; } }
        public GameContext Context { get { return m_context; } }
        public GameMode GameMode { get { return m_context.param.mode; } }
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

            Debuger.Log(LOG_TAG, "Create() param:{0}", param);

            //创建上下文，保存战斗全局参数
            m_context = new GameContext();
            m_context.param = param;
            m_context.random.Seed = param.randSeed;
            m_context.currentFrameIndex = 0;

            //创建地图
            m_map = new GameMap();
            m_map.Load(param.mapData);

            //初始化工厂
            EntityFactory.Init();
            ViewFactory.Init(GameObject.Find("EntityComponent").transform);

            m_isRunning = true;
        }

        public void ReleaseGame()
        {
            if (!m_isRunning)
            {
                return;
            }

            m_isRunning = false;

            for (int i = 0; i < m_listPlayer.Count; ++i)
            {
                m_listPlayer[i].Release();
            }
            m_listPlayer.Clear();

            if (m_map != null)
            {
                m_map.Unload();
                m_map = null;
            }

            onPlayerDie = null;
        }

        //======================================================================

        public void EnterFrame(int frameIndex)
        {
            if (!m_isRunning)
            {
                return;
            }

            if (frameIndex < 0)
            {
                m_context.currentFrameIndex++;
            }
            else
            {
                m_context.currentFrameIndex = frameIndex;
            }

            for (int i = 0; i < m_listPlayer.Count; ++i)
            {
                m_listPlayer[i].EnterFrame(frameIndex);
            }

            if (m_map != null)
            {
                m_map.EnterFrame(frameIndex);
            }

            //List<uint> listDiePlayerId = new List<uint>();

            //CheckDie

            //if (onPlayerDie != null)
            //{
            //    for (int i = 0; i < listDiePlayerId.Count; ++i)
            //    {
            //        onPlayerDie(listDiePlayerId[i]);
            //    }
            //}
        }

        public void RegPlayerData(PlayerData data)
        {
            m_mapPlayerData[data.id] = data;
        }

        public void CreatePlayer(int playerId)
        {
            Player player = new Player();

            PlayerData data = m_mapPlayerData[playerId];
            Vector3 pos = new Vector3();

            player.Create(data, pos);
            m_listPlayer.Add(player);
        }

        public void ReleasePlayer(int playerId)
        {

        }

        internal Player GetPlayer(int playerId)
        {
            int index = GetPlayerIndex(playerId);
            if (index >= 0)
            {
                return m_listPlayer[index];
            }
            return null;
        }

        private int GetPlayerIndex(int playerId)
        {
            for (int i = 0; i < m_listPlayer.Count; i++)
            {
                if (m_listPlayer[i].Id == playerId)
                {
                    return i;
                }
            }
            return -1;
        }

        public void InputVKey(int vkey, float arg, int playerId)
        {
            if (playerId == 0)
            {
                //处理其它VKey，全局性的VKey
                HandleOtherVKey(vkey, arg, playerId);
            }
            else
            {
                Player player = GetPlayer(playerId);
                if (player != null)
                {
                    player.InputVKey(vkey, arg);
                }
                else
                {
                    //处理其它Vkey
                    HandleOtherVKey(vkey, arg, playerId);

                }
            }
        }

        private void HandleOtherVKey(int vkey, float arg, int playerId)
        {
            //全局的VKey处理
            bool hasHandled = false;
            hasHandled = hasHandled || DoVKey_CreatePlayer(vkey, arg, playerId);
            hasHandled = hasHandled || DoVKey_ReleasePlayer(vkey, arg, playerId);
        }

        private bool DoVKey_CreatePlayer(int vkey, float arg, int playerId)
        {
            if (vkey == GameVKey.CreatePlayer)
            {
                CreatePlayer(playerId);
                return true;
            }

            return false;
        }

        private bool DoVKey_ReleasePlayer(int vkey, float arg, int playerId)
        {
            //服务端通知
            //if (vkey == FSPVKeyBase.GAME_EXIT)
            //{
            //    ReleasePlayer(playerId);
            //    return true;
            //}

            return false;
        }
    }
}
