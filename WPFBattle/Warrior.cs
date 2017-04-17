using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.RPGCore
{
    public class Warrior : CharacterBase
    {
        public Warrior(string name, int health)
        {
            this.CharacterClass = "Warrior";
            this.Name = name;
            this.Health = health;
        }

        public Warrior(string name)
            : this(name, GameConstants.Instance.PlayerHitpoints)
        {
        }
        public Warrior()
            : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(),
              GameConstants.Instance.PlayerHitpoints)
        {
        }
    }
}
