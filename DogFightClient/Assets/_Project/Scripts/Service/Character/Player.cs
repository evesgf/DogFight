using LarkFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class Player
    {
        private string LOG_TAG = "Player";

        private PlayerData m_data = new PlayerData();
        private GameObject m_container;
        private GameContext m_context;

        //----------------------------------------------------------------------
        /// <summary>
        /// 作为Player实体，有些功能需要用组合的方式去实现，从而需要有组件的概念
        /// 并不是每一个Entity都会有组件的
        /// </summary>
        //private List<PlayerComponent> m_listCompoent = new List<PlayerComponent>();

        //======================================================================

        public int Id { get { return m_data.id; } }
        public PlayerData Data { get { return m_data; } }
        public ShipData ShipData { get { return m_data.shipData; } }
        public GameObject Container { get { return m_container; } }

        public ShipBase m_Shap;

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        public void Create(PlayerData data, Vector3 pos)
        {
            LOG_TAG = LOG_TAG + "[" + data.id + "]";
            m_data = data;
            m_context = GameManager.Instance.Context;

            //创建用来显示视图的容器
            m_container = new GameObject("_Ship" + data.id);

            //创建飞船
            m_Shap = EntityFactory.InstanceEntity<ShipBase>();
            m_Shap.Create(pos, "Ships/AXS/AXS", GameObject.Find("Ship_Avatar").transform);
        }

        public void Release()
        {
            if (m_container != null)
            {
                GameObject.Destroy(m_container);
                m_container = null;
            }

            m_context = null;
        }

        //======================================================================

        public void EnterFrame(int frameIndex)
        {
            HandleMove();
        }

        public void InputVKey(int vkey, float arg)
        {
            bool hasHandled = false;
            hasHandled = hasHandled || DoVKey_Move(vkey, arg);
        }

        private Vector3 m_MoveDirection = new Vector3();
        public Vector3 MoveDirection { get { return m_MoveDirection; } }
        private Vector3 m_InputMoveDirection = new Vector3();
        private float m_Skill1 = 1;
        private bool DoVKey_Move(int vkey, float args)
        {
            switch (vkey)
            {
                case GameVKey.MoveX:
                    m_InputMoveDirection.x = args;
                    break;
                case GameVKey.MoveY:
                    m_InputMoveDirection.z = args;
                    break;
                case GameVKey.Skill_H1:
                    m_Skill1 = args;
                    break;
                default:
                    return false;
            }

            return true;
        }

        private void HandleMove()
        {
            m_MoveDirection = m_InputMoveDirection;
        }
    }
}
