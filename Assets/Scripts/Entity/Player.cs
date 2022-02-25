using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class Player : Entity
    {
        public override void Init(string name)
        {
            base.Init(name);
            m_entity.transform.position = new Vector3(1, 0, 1);
            m_entity.tag = "Player";
        }

        protected override void SubHp(int hp)
        {
            
        }

        protected override void Dead()
        {
            base.Dead();
        }
    }
}
