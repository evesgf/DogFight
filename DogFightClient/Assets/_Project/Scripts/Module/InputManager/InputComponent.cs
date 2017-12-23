using DigitalRubyShared;
using LarkFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    /// <summary>
    /// 输入组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Project/Input Component")]
    public class InputComponent : SingletonMono<InputComponent>
    {
        public Button btn_Skill1;
        public FingersJoystickScript JoystickScript;

        public GameObject Mover;

        public float Speed = 250.0f;

        /// <summary>
        /// 为调用者抛出虚拟按键事件
        /// </summary>
        public static Action<int, float> OnVkey;

        private bool isShowPanel;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            HideInputPanel();
        }

        private void OnBtnSkill1()
        {
            HandleVKey(GameVKey.Skill_H1, 1);
        }

        private void JoystickExecuted(FingersJoystickScript script, Vector2 amount)
        {
            if (!isShowPanel) return;
            //if (Mover == null) return;

            //Vector3 pos = Mover.transform.position;
            //pos.x += (amount.x * Speed * Time.deltaTime);
            //pos.z += (amount.y * Speed * Time.deltaTime);
            //Mover.transform.position = pos;

            HandleVKey(GameVKey.MoveX, amount.x);
            HandleVKey(GameVKey.MoveY, amount.y);
        }

        /// <summary>
        /// 虚拟按键的处理
        /// </summary>
        /// <param name="vkey"></param>
        /// <param name="arg"></param>
        private void HandleVKey(int vkey, float arg)
        {
            if (OnVkey != null)
            {
                OnVkey(vkey, arg);
            }
        }

        public void ShowInputPanel()
        {
            isShowPanel = true;
            btn_Skill1.onClick.AddListener(OnBtnSkill1);
            JoystickScript.gameObject.SetActive(isShowPanel);
            JoystickScript.JoystickExecuted += JoystickExecuted;
        }

        public void HideInputPanel()
        {
            isShowPanel = false;
            btn_Skill1.onClick.RemoveListener(OnBtnSkill1);
            JoystickScript.JoystickExecuted -= JoystickExecuted;
            JoystickScript.gameObject.SetActive(isShowPanel);
        }

        //#region 键盘控制
        //void Update()
        //{
        //    HandleKey(KeyCode.A, GameVKey.MoveX, -1, GameVKey.MoveX, 0);
        //    HandleKey(KeyCode.D, GameVKey.MoveX, 1, GameVKey.MoveX, 0);
        //    HandleKey(KeyCode.W, GameVKey.MoveY, 1, GameVKey.MoveY, 0);
        //    HandleKey(KeyCode.S, GameVKey.MoveY, -1, GameVKey.MoveY, 0);
        //}

        ///// <summary>
        ///// 对【物理按键】的轮询处理
        ///// 将【物理按键】转化为【虚拟按键】
        ///// </summary>
        ///// <param name="key">所轮询的物理按键KeyCode</param>
        ///// <param name="press_vkey">当物理按键按下时，对应的虚拟按键VKeyCode</param>
        ///// <param name="press_arg">当物理按键按下时，对应的虚拟按键参数</param>
        ///// <param name="release_vkey">当物理按键松开时，对应的虚拟按键VKeyCode</param>
        ///// <param name="relase_arg">当物理按键松开时，对应的虚拟按键参数</param>
        //private void HandleKey(KeyCode key, int press_vkey, float press_arg, int release_vkey, float relase_arg)
        //{
        //    if (Input.GetKey(key))
        //    {
        //        if (!m_MapKeyState[key])
        //        {
        //            m_MapKeyState[key] = true;
        //            HandleVKey(press_vkey, press_arg);//转为虚拟按键
        //        }
        //    }
        //    else
        //    {
        //        if (m_MapKeyState[key])
        //        {
        //            m_MapKeyState[key] = false;
        //            HandleVKey(release_vkey, relase_arg);//转为虚拟按键
        //        }
        //    }
        //}
        //#endregion
    }
}
