using LarkFramework.Procedure;
using LarkFramework.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class QuickStartWind : LarkFramework.UI.UIWindow
    {
        public Button btn_NormalMode;
        public Button btn_GroundMode;
        public Button btn_SpaceMode;
        public Button btn_CommondMode;

        public Button btn_Return;

        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);

            //Button
            btn_NormalMode.onClick.AddListener(OnNormalMode);
            btn_GroundMode.onClick.AddListener(OnGroundMode);
            btn_SpaceMode.onClick.AddListener(OnSpaceMode);
            btn_CommondMode.onClick.AddListener(OnCommondMode);
            btn_Return.onClick.AddListener(OnReturn);

            GUIAniOpen();
        }

        public override void Close(float waitSeconds, object arg = null)
        {
            GUIAniClose();

            base.Close(waitSeconds, arg);
        }

        protected override void OnClose(object arg = null)
        {
            //Button
            btn_NormalMode.onClick.RemoveListener(OnNormalMode);
            btn_GroundMode.onClick.RemoveListener(OnGroundMode);
            btn_SpaceMode.onClick.RemoveListener(OnSpaceMode);
            btn_CommondMode.onClick.RemoveListener(OnCommondMode);
            btn_Return.onClick.RemoveListener(OnReturn);

            base.OnClose(arg);
        }

        public void OnNormalMode()
        {
            Close(1f);

            ProcedureManager.Instance.ChangeProcedure<ProcedureSearch>();
        }

        public void OnGroundMode()
        {

        }

        public void OnSpaceMode()
        {

        }

        public void OnCommondMode()
        {

        }

        public void OnReturn()
        {
            Close(1f);
            UIManager.Instance.OpenWindow(UIDef.MenuWindow);
        }
    }
}
