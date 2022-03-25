using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class EntityData : DataBase
    {
        private int m_uuid;
        private string m_name;
        private int m_maxHp;
        private int m_hp;
        private int m_atk;

        public override void Load(PropertyBase datas)
        {
            EntityPropertys.Propertys propertys = datas as EntityPropertys.Propertys;
            m_uuid = propertys.uuid;
            m_name = propertys.name;
            m_hp = m_maxHp = propertys.maxHp;
            m_atk = propertys.atk;
        }

        public int GetUuid()
        {
            return m_uuid;
        }

        public string GetName()
        {
            return m_name;
        }

        public int GetMaxHp()
        {
            return m_maxHp;
        }

        public int GetAtk()
        {
            return m_atk;
        }
    }
}
