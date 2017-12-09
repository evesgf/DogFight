using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class GameMap
    {
        private MapScript m_script;
        private GameObject m_view;

        public void Load(MapData data)
        {
            Debuger.Log("GameMap Load():" + data.name);
        }

        public void Unload()
        {
            Debuger.Log("GameMap UnLoad()");
        }

        public void EnterFrame(int frameIndex)
        {
            if (m_script != null)
            {
                m_script.EnterFrame(frameIndex);
            }
        }
    }
}
