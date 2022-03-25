using System;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class EntityPropertys : Singleton<EntityPropertys>, PropertysInterface
    {
        [Serializable]
        public class Propertys : PropertyBase
        {
            public int uuid;
            public string name;
            public int maxHp;
            public int atk;
        }

        public string PropersToString(DataBase data)
        {
            Propertys propertys = new Propertys();
            EntityData entityData = data as EntityData;
            propertys.uuid = entityData.GetUuid();
            propertys.name = entityData.GetName();
            propertys.maxHp = entityData.GetMaxHp();
            propertys.atk = entityData.GetAtk();
            return JsonUtility.ToJson(propertys);
        }

        public PropertyBase StringToPropers(string propers)
        {
            return JsonUtility.FromJson<Propertys>(propers);
        }
    }
}
