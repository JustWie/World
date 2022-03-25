using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class BagMgr: Singleton<BagMgr>, ManagerInterface
    {
        string path;

        public void LoadData()
        {
            path = Lib.GetPath("bag.json");
            string fileText = Lib.ReadFile(path);
            var data = BagPropertys.ins.StringToPropers(fileText);
            Singleton<BagData>.ins.Load(data);
        }

        public void SaveData()
        {
            var data = Singleton<BagData>.ins;
            string fileText = BagPropertys.ins.PropersToString(data);
            Lib.WriteFile(path, fileText);
        }

        public void AddItems(List<string> items)
        {
            Singleton<BagData>.ins.AddItems(items);
        }

        public void DeleteItem(string item, int num)
        {
            Singleton<BagData>.ins.DeleteItem(item, num);
        }

        public void RefreshItem()
        {
            var items = Singleton<BagData>.ins.GetBagItems();
            WorldEvent.ins.SendRefreshItemSignal(items);
        }
    }
}
