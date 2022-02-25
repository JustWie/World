using System;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class Propertys
    {
        [Serializable]
        public struct PlayerProperty
        {
            public int atk;
            public int maxHp;
        }

        [Serializable]
        public struct BossProperty
        {
            public string name;
            public int maxHp;
        }

        [Serializable]
        public struct BagItem
        {
            public string type;
            public int count;
        }

        [Serializable]
        public struct Datas
        {
            public PlayerProperty playerPropertys;
            public BossProperty bossPropertys;
            public List<BagItem> bagItems;
        }

        static PlayerProperty PlayerPropertys()
        {
            var playerData = new PlayerProperty();
            int atk = Singleton<PlayerData>.ins.GetATK();
            playerData.atk = atk <= 0 ? 1 : atk;
            int maxHp = Singleton<PlayerData>.ins.GetMaxHp();
            playerData.maxHp = maxHp <= 0 ? 20 : maxHp;
            return playerData;
        }

        static BossProperty BossPropertys()
        {
            var bossData = new BossProperty();
            string name = Singleton<BossData>.ins.GetName();
            bossData.name = string.IsNullOrEmpty(name) ? "Boss" : name;
            int maxHp = Singleton<BossData>.ins.GetMaxHp();
            bossData.maxHp = maxHp <= 0 ? 20 : maxHp;
            return bossData;
        }

        static List<BagItem> BagItems()
        {
            var bagItems = new List<BagItem>();
            var bagData = Singleton<BagData>.ins.GetBagData();
            foreach (string type in bagData.Keys)
            {
                int count = bagData[type].Count;
                BagItem item = new BagItem();
                item.type = type;
                item.count = count;
                bagItems.Add(item);
            }
            return bagItems;
        }

        public static string DatasToString()
        {
            Datas datas = new Datas();
            datas.playerPropertys = PlayerPropertys();
            datas.bossPropertys = BossPropertys();
            datas.bagItems = BagItems();
            return JsonUtility.ToJson(datas);
        }

        public static Datas StringToDatas(string datas)
        {
            return JsonUtility.FromJson<Datas>(datas);
        }
    }
}
