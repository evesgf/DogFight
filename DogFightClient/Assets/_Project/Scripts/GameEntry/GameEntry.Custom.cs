using LarkFramework.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public partial class GameEntry
    {
        public void InitCustomComponents()
        {
            GameManager.Instance.Init();

            ModuleManager.Instance.CreateModule("DrillModule");

            InputComponent.Create().Init();
        }
    }
}
