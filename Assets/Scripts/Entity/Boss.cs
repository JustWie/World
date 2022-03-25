using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class Boss : Entity
    {
        private Transform _left;
        private Transform _right;
        private DropItem _dropItem;
        private bool _transform = true;

        public override void Init(string name)
        {
            base.Init(name);
            m_entity.transform.position = Vector3.zero;
            _left = m_entity.transform.Find("Left");
            _right = m_entity.transform.Find("Right");

            //Singleton<BossData>.ins.UnderFireAction += SubHp;
            _dropItem = new DropItem();

            WorldEvent.ins.UnderFireAction += SubHp;
        }

        protected override void SubHp(int hp)
        {
            /*if (hp <= Singleton<BossData>.ins.GetMaxHp() / 3 && _transform)
            {
                _left.gameObject.SetActive(false);
                _right.gameObject.SetActive(false);
                _transform = false;
            }
            if (hp <= 0)
                Dead();*/
            Dead();
        }

        protected override void Dead()
        {
            var drops = _dropItem.Drop();
            for (int i = 0; i < drops.Count; i++)
            {
                GameObject instance = Lib.CreateGameObject(string.Format("DropItem/{0}", drops[i]));
                instance.transform.position = new Vector3(m_entity.transform.position.x, 0, m_entity.transform.position.z + i);
                Object.Destroy(instance, 3);
            }
            BagMgr.ins.AddItems(drops);
            //Singleton<BossData>.ins.OnDead();
            base.Dead();
        }
    }
}
