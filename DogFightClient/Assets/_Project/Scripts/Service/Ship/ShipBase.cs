using LarkFramework.Entity;
using LarkFramework.Entity.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class ShipBase : EntityObject
    {
        private Vector3 m_pos;

        public void Create(Vector3 pos,string path,Transform parent)
        {
            m_pos = pos;

            ViewFactory.CreateView(path, "ship01", this, parent);
        }

        protected override void Release()
        {
            ViewFactory.ReleaseView(this);
        }

        public override Vector3 Position()
        {
            return m_pos;
        }
    }
}
