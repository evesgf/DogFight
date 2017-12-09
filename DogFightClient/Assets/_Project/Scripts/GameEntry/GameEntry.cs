using System.Collections;
using System.Collections.Generic;
using LarkFramework;
using LarkFramework.Module;
using LarkFramework.ResourcesMgr;
using LarkFramework.Scenes;
using LarkFramework.Scenes.Example;
using LarkFramework.UI;
using UnityEngine;

namespace Project
{
    [DisallowMultipleComponent]
    [AddComponentMenu("LarkFramework/GameEntry")]
    public partial class GameEntry : MonoBehaviour
    {
        public LaunchType lanuchType = LaunchType.Debug;
        public string startScene;
        public string startUI;
        public string startAudio;

        public enum LaunchType
        {
            Debug = 1,
            Release = 2,
        }

        // Use this for initialization
        void Awake()
        {
            Init();
        }

        public void Init()
        {
            switch (lanuchType)
            {
                case LaunchType.Debug:
                    DebugLaunch();
                    break;

                case LaunchType.Release:
                    ReleaseLaunch();
                    break;
            }

            LarkFramework.GameEntry.GameEntry.InitBuiltinComponents();
            InitCustomComponents();

            DontDestroyOnLoad(gameObject);
        }

        private void DebugLaunch()
        {
            Debuger.EnableLog = true;
        }

        private void ReleaseLaunch()
        {
            Debuger.EnableLog = false;
        }
    }

}
