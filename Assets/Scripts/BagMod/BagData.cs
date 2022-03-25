using System;
using System.Collections.Generic;

namespace World
{
    public class BagData : DataBase
    {
        private Dictionary<string, List<string>> m_bagItems = new Dictionary<string, List<string>>();

        public override void Load(PropertyBase datas)
        {
            BagPropertys.Propertys propertys = datas as BagPropertys.Propertys;
            List<string> list = new List<string>();
            foreach (BagPropertys.BagItem item in propertys.bagItems)
            {
                for (int i = 0; i < item.count; i++)
                {
                    list.Add(item.item);
                }
            }
            AddItems(list);
        }

        public void AddItems(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                AddItem(items[i]);
            }
        }

        public void AddItem(string item)
        {
            List<string> list = null;
            if (!m_bagItems.ContainsKey(item))
            {
                list = new List<string>();
                m_bagItems.Add(item, list);
            }
            else
            {
                list = m_bagItems[item];
            }
            list.Add(item);
        }

        public bool DeleteItem(string item, int num)
        {
            var list = m_bagItems[item];
            if (list.Count <= 0)
            {
                m_bagItems.Remove(item);
                return false;
            }
            for (int i = 0; i < num; i++)
            {
                list.Remove(item);
            }
            return true;
        }

        public Dictionary<string, List<string>> GetBagItems()
        {
            return m_bagItems;
        }
    }
}
