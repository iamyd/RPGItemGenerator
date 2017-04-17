using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Du.RPGCore;
using System.Threading;

namespace WPFBattle
{
    public class CombatThread
    {
        private ICombat encounter;
        private Thread thread;

        public CombatThread(ICombat c)
        {
            encounter = c;
        }
        public void Start()
        {
            thread = new System.Threading.Thread(() => //give this code
            {
                encounter.AutoBattle();
            });
            thread.Name = "GameThread";
            thread.Start();
        }
        public void Deactivate()
        {
            thread.Abort();
        }
    }
}
