using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class MapPropertys : Singleton<MapPropertys>
    {
        [Serializable]
        public struct Propertys
        {
            public int[] entitysID;
        }

        
    }
}
