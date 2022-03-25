using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    interface PropertysInterface
    {
        string PropersToString(DataBase data);
        PropertyBase StringToPropers(string propers);
    }

    interface ManagerInterface
    {
        void LoadData();
        void SaveData();
    }
}
