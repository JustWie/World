using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class DropItem
    {
        public List<string> Drop()
        {
            List<string> drops = new List<string>();
            int items = Random.Range(1, 5);
            for (int i = 0; i < items; i++)
            {
                if (Lib.Odds(5))
                {
                    if (Lib.Odds(5))
                        drops.Add(DropItemType.MainItem_Perfect.ToString());
                    else if (Lib.Odds(10))
                        drops.Add(DropItemType.MainItem_Excellent.ToString());
                    else if(Lib.Odds(20))
                        drops.Add(DropItemType.MainItem_Well.ToString());
                    else if(Lib.Odds(50))
                        drops.Add(DropItemType.MainItem_Common.ToString());
                    else
                        drops.Add(DropItemType.MainItem_Inferior.ToString());
                }
                if (Lib.Odds(80))
                {
                    drops.Add(DropItemType.ComplementItem.ToString());
                }
            }
            
            return drops;
        }
    }
}
