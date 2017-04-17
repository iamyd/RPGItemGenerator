using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBattle;

namespace Du.RPGCore
{
    public class MageSubclass : CharacterBase
    {
        Image image;
        public MageSubclass(string name, int health, CharacterImage i)
        {
            this.CharacterClass = "Mage";
            this.image = new Image(i);
            this.attackBehavior = new FireAttackSubclass(image);
            this.Name = name;
            this.Health = health;
        }

        public MageSubclass(string name, CharacterImage i)
            : this(name, GameConstants.Instance.PlayerHitpoints, i)
        {
        }
        public MageSubclass(CharacterImage i)
            : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(),
       GameConstants.Instance.PlayerHitpoints,i)
        {
        }

        public override void ReceiveAttack(int damage)
        {

            if (randomNumbers.Next(GameConstants.Instance.DodgeDifficulty) != 0)
            {
                Console.WriteLine(this.Name + " takes " + damage + " damage.");
                Health -= damage;
                if (Health < 0)
                {
                    Health = 0;
                    image.Dead();
                }
                else
                {
                    image.TakeDamage();
                    System.Threading.Thread.Sleep(1000);
                    image.Idle();
                }

            }
            else
            {
                Console.WriteLine(this.Name + " dodges the Attack!");
            }

        }
    }
}