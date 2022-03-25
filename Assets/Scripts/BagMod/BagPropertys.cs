using System;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class BagPropertys : Singleton<BagPropertys>, PropertysInterface
    {
        [Serializable]
        public struct BagItem
        {
            public string item;
            public int count;
        }

        [Serializable]
        public class Propertys : PropertyBase
        {
            public List<BagItem> bagItems;
        }

        List<BagItem> BagItems(BagData data)
        {
            var bagItemList = new List<BagItem>();
            var bagItems = data.GetBagItems();
            foreach (string item in bagItems.Keys)
            {
                int count = bagItems[item].Count;
                BagItem bagItem = new BagItem();
                bagItem.item = item;
                bagItem.count = count;
                bagItemList.Add(bagItem);
            }
            return bagItemList;
        }

        public string PropersToString(DataBase data)
        {
            Propertys propertys = new Propertys();
            BagData bagData = data as BagData;
            propertys.bagItems = BagItems(bagData);
            return JsonUtility.ToJson(propertys);
        }

        public PropertyBase StringToPropers(string propers)
        {
            return JsonUtility.FromJson<Propertys>(propers);
        }
    }
}
