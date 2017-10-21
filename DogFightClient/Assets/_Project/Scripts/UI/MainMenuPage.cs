using LarkFramework.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class MainMenuPage : UIPage
    {

        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);

            UIManager.Instance.OpenWindow(UIDef.MenuWindow);
        }
    }
}
