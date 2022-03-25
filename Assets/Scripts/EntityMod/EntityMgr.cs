using System;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class EntityMgr : Singleton<EntityMgr>, ManagerInterface
    {
        int playerID = 0;
        string m_path;
        Dictionary<int, EntityData> entityUuidDic = new Dictionary<int, EntityData>();
        Dictionary<string, EntityData> entityPathDic = new Dictionary<string, EntityData>();

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
                entityUuidDic.Add(entityData.GetUuid(), entityData);
                entityPathDic.Add(path, entityData);
            }

        }

        public void SaveData()
        {
            foreach (string path in entityPathDic.Keys)
            {
                var data = entityPathDic[path];
                string fileText = EntityPropertys.ins.PropersToString(data);
                Lib.WriteFile(path, fileText);
            }
        }

        public bool IsPlayer(int uuid)
        {
            return uuid == playerID;
        }

        public EntityData GetPlayerData()
        {
            return GetEntityData(playerID);
        }

        public EntityData GetEntityData(int uuid)
        {
            return entityUuidDic[uuid];
        }

        public void SetEntityHp(int uuid, int hp)
        {
            GetEntityData(uuid).SetHp(hp);
            WorldEvent.ins.SendRefreshHpSignal(uuid, hp);
            if (hp <= 0)
                WorldEvent.ins.SendEntityDeadSignal(uuid);
        }
    }
}
