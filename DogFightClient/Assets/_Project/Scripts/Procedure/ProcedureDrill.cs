using LarkFramework.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LarkFramework.FSM;
using LarkFramework.Module;
using LarkFramework.UI;
using LarkFramework.Audio;
using LarkFramework.Scenes;

namespace Project
{
    public class ProcedureDrill: ProcedureBase
    {
        private DrillModule drillModule;

        protected internal override void OnInit(IFSM<ProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);

        }

        protected internal override void OnEnter(IFSM<ProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            //加载UI
            UIManager.Instance.OpenPage(UIDef.DrillModePage);

            //加载BGM
            AudioManager.Instance.PlayBGM(AudioDef.BGM_DrillBGM, 0.2f);

            drillModule = ModuleManager.Instance.GetModule("DrillModule") as DrillModule;
            drillModule.Show();
        }

        protected internal override void OnUpdate(IFSM<ProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //循环调用
            drillModule.GetCurrentGame().FixedUpdate(elapseSeconds, realElapseSeconds);
        }

        protected internal override void OnLeave(IFSM<ProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            drillModule.Release();
        }
    }
}
