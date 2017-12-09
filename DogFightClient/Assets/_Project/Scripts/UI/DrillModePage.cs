using LarkFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class DrillModePage: UIPage
    {
        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);

            GUIAniOpen();
        }

        public override void Close()
        {
            GUIAniClose();

            base.Close();
        }
    }
}
