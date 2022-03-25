using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace World
{
    public class Player : Entity
    {
        NavMeshAgent agent;
        public override void Init(string name)
        {
            base.Init(name);
            m_entity.transform.position = new Vector3(1, 0, 1);
            m_entity.tag = "Player";

            agent = m_entity.GetComponent<NavMeshAgent>();
            if (agent == null)
                agent = m_entity.AddComponent<NavMeshAgent>();
        }

        protected override void SubHp(int hp)
        {
            
        }

        protected override void Dead()
        {
            base.Dead();
        }

        public void MoveTo(Vector3 targetPos)
        {
            agent.destination = targetPos;
        }
    }
}
