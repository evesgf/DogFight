using LarkFramework.Entity;
using LarkFramework.Entity.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Project
{
    public class Ship01 : ViewObject
    {
        public float rotateSpped;
        public Transform weaponRoot;

        [SerializeField]
        private Vector3 m_entityPosition;
        [SerializeField]
        private Vector3 m_entityQuate;

        private ShipBase m_entity;

        //private WeaponBase weapon;

        protected override void Create(EntityObject entity)
        {
            m_entity = entity as ShipBase;
            m_entityPosition = m_entity.Position();
            this.transform.localPosition = m_entityPosition;
            Debug.Log("Create:" + m_entity);

            //weapon = EntityFactory.InstanceEntity<WeaponBase>();
            //weapon.Create(weaponRoot);
        }

        protected override void Release()
        {
            m_entity = null;
        }

        private void Update()
        {
            if (m_entity != null)
            {
                gameObject.transform.rotation = m_entity.Quate();
                //gameObject.transform.Rotate(new Vector3(0, m_entityQuate.x * rotateSpped,m_entityQuate.z* rotateSpped));
                gameObject.transform.localPosition = m_entity.Position();
            }
        }
    }
}
