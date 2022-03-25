using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class Entity
    {
        protected GameObject m_entity;

        public GameObject GetObject()
        {
            return m_entity;
        }

        public virtual void Init(string name)
        {
            m_entity = Lib.CreateGameObject(name);
        }

        protected virtual void SubHp(int hp) { }

        protected virtual void Dead()
        {
            Object.Destroy(m_entity);
        }
    }
}
