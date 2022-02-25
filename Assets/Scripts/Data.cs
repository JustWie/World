using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    interface DataInterface
    {
        void Load(Propertys.Datas datas);
    }

    public class EntityData
    {
        public Action<int> UnderFireAction;
        public Action<string> DeadAction;

        protected string _name;
        protected int _atk;
        protected int _maxHp;
        protected int _hp;

        public string GetName()
        {
            return _name;
        }

        public int GetATK()
        {
            return _atk;
        }

        public int GetMaxHp()
        {
            return _maxHp;
        }

        public void UnderFire(int atk)
        {
            if (_hp <= 0) return;
            _hp -= atk;
            UnderFireAction?.Invoke(_hp < 0 ? 0 : _hp);
        }

        public void OnDead()
        {
            DeadAction?.Invoke(_name);
        }
    }

    #region PlayerData
    public class PlayerData: EntityData, DataInterface
    {
        public void Load(Propertys.Datas datas)
        {
            _atk = datas.playerPropertys.atk;
            _hp = _maxHp = datas.playerPropertys.maxHp;
        }
    }
    #endregion

    #region BossData
    public class BossData: EntityData, DataInterface
    {
        public void Load(Propertys.Datas datas)
        {
            _name = datas.bossPropertys.name;
            _hp = _maxHp = datas.bossPropertys.maxHp;
        }
    }
    #endregion

    #region BagData
    public class BagData: DataInterface
    {
        private Dictionary<string, List<string>> _bagData = new Dictionary<string, List<string>>();

        public void Load(Propertys.Datas datas)
        {
            List<string> list = new List<string>();
            foreach (Propertys.BagItem item in datas.bagItems)
            {
                for (int i = 0; i < item.count; i++)
                {
                    list.Add(item.type);
                }
            }
            AddItem(list);
        }

        public void AddItem(List<string> items)
        {
            List<string> list = null;
            for (int i = 0; i < items.Count; i++)
            {
                var type = items[i];
                if (!_bagData.ContainsKey(type))
                {
                    list = new List<string>();
                    _bagData.Add(items[i], list);
                }
                else
                {
                    list = _bagData[type];
                }
                list.Add(type);
            }
        }

        public bool DeleteItem(string type, int num)
        {
            var list = _bagData[type];
            if (list.Count <= 0)
            {
                _bagData.Remove(type);
                return false;
            }
            for (int i = 0; i < num; i++)
            {
                list.Remove(type);
            }
            return true;
        }

        public Dictionary<string, List<string>> GetBagData()
        {
            return _bagData;
        }
    }
    #endregion
}
