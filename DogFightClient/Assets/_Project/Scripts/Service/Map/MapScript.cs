using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class MapScript : MonoBehaviour
    {
        void Start()
        {
            print("MapScript Start()");
        }

        public void EnterFrame(int frameIndex)
        {
            print("MapScript EnterFrame():" + frameIndex);
        }
    }
}
