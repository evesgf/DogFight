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
        /// <summary>
        /// 当用键盘输入时，用来记录按键状态
        /// </summary>
        private static Dictionary<KeyCode, bool> m_MapKeyState = new Dictionary<KeyCode, bool>();

        /// <summary>
        /// 为调用者抛出虚拟按键事件！
        /// </summary>
        public static Action<int, float> OnVkey;

        //-------------------------------------------------------------------
        /// <summary>
        /// 用来控制移动的轮盘
        /// </summary>
        private FingersJoystickScript m_Joystick;

        /// <summary>
        /// 用来加速，或者使用技能的按钮
        /// </summary>
        private Button m_Button;

        /// <summary>
        /// 初始化，用来在当前场景添加Input对象
        /// </summary>
        public void Init()
        {
            //实例化GameInput的Prefab，里面预置了EasyJoystick脚本！
            //因为EasyJoystick有一些参数，在Prefab里比较容易配置
            GameObject prefab = Resources.Load<GameObject>("GameInput");
            GameObject go = GameObject.Instantiate(prefab);
        }

        /// <summary>
        /// 释放Input对象
        /// </summary>
        public void Release()
        {

        }

        private void Start()
        {
            m_Joystick = this.GetComponentInChildren<FingersJoystickScript>();
            m_Button = this.GetComponentInChildren<Button>();

            if (m_Joystick == null || m_Button == null)
            {
                this.LogError("Start() m_Joystick == null || m_Button == null!");
            }
        }

        #region 对虚拟按键的处理
        /// <summary>
        /// 对【虚拟按键】的处理，将其通过事件回调，抛给监听者
        /// </summary>
        /// <param name="vkey">Vkey.</param>
        /// <param name="arg">Argument.</param>
        private void HandleVKey(int vkey, float arg)
        {
            if (OnVkey != null)
            {
                OnVkey(vkey, arg);
            }
        }
        #endregion

        #region 键盘控制
        void Update()
        {
            HandleKey(KeyCode.A, GameVKey.MoveX, -1, GameVKey.MoveX, 0);
            HandleKey(KeyCode.D, GameVKey.MoveX, 1, GameVKey.MoveX, 0);
            HandleKey(KeyCode.W, GameVKey.MoveY, 1, GameVKey.MoveY, 0);
            HandleKey(KeyCode.S, GameVKey.MoveY, -1, GameVKey.MoveY, 0);
        }

        /// <summary>
        /// 对【物理按键】的轮询处理
        /// 将【物理按键】转化为【虚拟按键】
        /// </summary>
        /// <param name="key">所轮询的物理按键KeyCode</param>
        /// <param name="press_vkey">当物理按键按下时，对应的虚拟按键VKeyCode</param>
        /// <param name="press_arg">当物理按键按下时，对应的虚拟按键参数</param>
        /// <param name="release_vkey">当物理按键松开时，对应的虚拟按键VKeyCode</param>
        /// <param name="relase_arg">当物理按键松开时，对应的虚拟按键参数</param>
        private void HandleKey(KeyCode key, int press_vkey, float press_arg, int release_vkey, float relase_arg)
        {
            if (Input.GetKey(key))
            {
                if (!m_MapKeyState[key])
                {
                    m_MapKeyState[key] = true;
                    HandleVKey(press_vkey, press_arg);//转为虚拟按键
                }
            }
            else
            {
                if (m_MapKeyState[key])
                {
                    m_MapKeyState[key] = false;
                    HandleVKey(release_vkey, relase_arg);//转为虚拟按键
                }
            }
        }
        #endregion
    }
}
