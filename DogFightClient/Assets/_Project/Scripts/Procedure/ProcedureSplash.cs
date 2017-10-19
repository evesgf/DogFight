using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LarkFramework.FSM;
using LarkFramework.Procedure;
using LarkFramework.UI;

namespace Project
{
    public class ProcedureSplash: ProcedureBase
    {
        public bool splashOver = false;

        protected internal override void OnInit(IFSM<ProcedureManager> procedureOwner)
        {
            base.OnInit(procedureOwner);

            splashOver = false;
        }

        protected internal override void OnEnter(IFSM<ProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            splashOver = false;

            //加载Splash动画
            UIManager.Instance.OpenPage(UIDef.SplashPage);
        }

        protected internal override void OnUpdate(IFSM<ProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            //检查版本

            //切换场景
            if (splashOver)
            {
                ProcedureManager.Instance.ChangeProcedure<ProcedureChageScene>();
            }
        }

        protected internal override void OnLeave(IFSM<ProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }
    }
}
