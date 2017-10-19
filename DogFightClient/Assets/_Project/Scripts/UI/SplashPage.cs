using System;
using System.Collections;
using System.Collections.Generic;
using LarkFramework.Procedure;
using LarkFramework.UI;
using UnityEngine;

namespace Project
{
    public class SplashPage : UIPage
    {
        public float showTime;
        public float closeWaitSecond;

        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);

            GUIAniOpen();

            StartCoroutine(ShowTime());
        }

        IEnumerator ShowTime()
        {
            yield return new WaitForSeconds(showTime);

            GUIAniClose();
            Close(closeWaitSecond);
        }

        protected override void OnClose(object arg = null)
        {
            base.OnClose(arg);

            var currentProcedure = ProcedureManager.Instance.CurrentProcedure as ProcedureSplash;
            if (currentProcedure != null)
            {
                currentProcedure.splashOver = true;
            }
            else
            {
                throw new Exception("SplashPage CurrentProcedure <ProcedureSplash> is null");
            }
        }
    }
}
