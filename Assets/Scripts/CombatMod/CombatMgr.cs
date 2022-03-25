using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class CombatMgr : Singleton<CombatMgr>
    {
        /// <summary>
        /// 普通攻击
        /// </summary>
        /// <param name="entity1ID">攻击者ID</param>
        /// <param name="entity2ID">被攻击者ID</param>
        public void NormalAttack(int entity1ID, int entity2ID)
        {
            var entity2Hp = EntityMgr.ins.GetEntityData(entity2ID).GetHp();
            if (entity2Hp <= 0)
                return;
            var entity1Atk = EntityMgr.ins.GetEntityData(entity1ID).GetAtk();
            entity2Hp -= entity1Atk;
            if (entity2Hp < 0)
                entity2Hp = 0;
            EntityMgr.ins.SetEntityHp(entity2ID, entity2Hp);
        }
    }
}
