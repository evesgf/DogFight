using LarkFramework.Procedure;
using LarkFramework.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class SearchWindow : LarkFramework.UI.UIWindow
    {
        public Text txt_WaitTime;   //等待了的时间
        public Image line;
        public float rotateTime;    //line旋转一圈的时间

        private float waitTimeSecond;

        public override void Close()
        {
            base.Close();

            ProcedureManager.Instance.ChangeProcedure<ProcedureHome>();
            UIManager.Instance.OpenWindow(UIDef.MenuWindow);
        }

        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);

            waitTimeSecond = 0;

            StartCoroutine(RotateLine());
        }

        IEnumerator RotateLine()
        {
            for (float i = rotateTime; i > 0; i -= Time.deltaTime)
            {
                line.fillAmount = (rotateTime - i )/ rotateTime;

                waitTimeSecond += Time.deltaTime;
                ShowTime();

                yield return rotateTime;
            }

            StartCoroutine(RotateLine());
        }

        private void ShowTime()
        {
            int m = (int)waitTimeSecond / 60;
            txt_WaitTime.text =m + ":"+ string.Format("{0:D2}", (int)(waitTimeSecond - m * 60));
        }
    }
}
