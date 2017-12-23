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
        private Quaternion m_quate;

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

        public override Quaternion Quate()
        {
            return m_quate;
        }

        internal void MoveTo(Vector3 pos)
        {
            m_pos = pos;
        }

        internal void QuateTo(Quaternion quate)
        {
            m_quate = quate;
        }
    }
}
