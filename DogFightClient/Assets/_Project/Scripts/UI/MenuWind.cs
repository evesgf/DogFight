
using LarkFramework.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    /// <summary>
    /// MneuWindow
    /// 名字不能起MenuWindow，和unity内部类冲突
    /// </summary>
	public class MenuWind : LarkFramework.UI.UIWindow
    {
		public Button btn_QuickStart;
		
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen(arg);

            //Button
            btn_QuickStart.onClick.AddListener(OnQuickStart);

            GUIAniOpen();
		}
		
		public override void Close(float waitSeconds, object arg = null)
		{
            //Button
            btn_QuickStart.onClick.RemoveListener(OnQuickStart);
            GUIAniClose();

            base.Close(waitSeconds, arg);
		}

        public void OnQuickStart()
        {
            Close(1f);
            UIManager.Instance.OpenWindow(UIDef.QuickStartWindow);
        }

    }
}
