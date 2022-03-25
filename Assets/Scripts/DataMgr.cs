using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class DataMgr
    {
        public static void RegisterLoad()
        {
            BagMgr.ins.LoadData();
            EntityMgr.ins.LoadData();
        }

        public static void RegisterSave()
        {
            BagMgr.ins.SaveData();
            EntityMgr.ins.SaveData();
        }
    }
}
