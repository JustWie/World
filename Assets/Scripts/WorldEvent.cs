using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class WorldEvent : Singleton<WorldEvent>
    {
        public Action<Dictionary<string, List<string>>> RefreshItemAction;
        public void SendRefreshItemSignal(Dictionary<string, List<string>> items)
        {
            RefreshItemAction?.Invoke(items);
        }

        public Action<int, int> RefreshHpAction;
        public void SendRefreshHpSignal(int uuid, int hp)
        {
            RefreshHpAction?.Invoke(uuid, hp);
        }

        public Action<int> EntityDeadAction;
        public void SendEntityDeadSignal(int uuid)
        {
            EntityDeadAction?.Invoke(uuid);
        }
    }
}
