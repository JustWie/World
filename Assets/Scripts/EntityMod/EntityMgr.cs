using System;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class EntityMgr : Singleton<EntityMgr>, ManagerInterface
    {
        string m_path;
        Dictionary<string, EntityData> entityDic = new Dictionary<string, EntityData>();

        public void LoadData()
        {
            m_path = Lib.GetPath("Entity");
            var fileNames = Lib.GetFileNames(m_path);
            foreach (string fileName in fileNames)
            {
                string path = m_path + "\\" + fileName;
                string fileText = Lib.ReadFile(path);
                var data = EntityPropertys.ins.StringToPropers(fileText);
                EntityData entityData = new EntityData();
                entityData.Load(data);
                entityDic.Add(path, entityData);
            }

        }

        public void SaveData()
        {
            foreach (string path in entityDic.Keys)
            {
                var data = entityDic[path];
                string fileText = EntityPropertys.ins.PropersToString(data);
                Lib.WriteFile(path, fileText);
            }
        }

        public void XXX()
        {
            WorldEvent.ins.SendUnderFire(1);
        }

    }
}
