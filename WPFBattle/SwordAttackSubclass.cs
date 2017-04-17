using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Du.RoleplayingGameInterfaces;

namespace Du.RPGCore
{
    public class SwordAttackSubclass : NormalAttack
    {
        private WPFBattle.Image image;

        public SwordAttackSubclass(WPFBattle.Image i)
        {
            image = i;
        }

        public override void Attack(ICharacter attacker, ICharacter target)
        {
            image.Attack();
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(attacker.Name + " swings a sword at " + target.Name +
           "!");
            base.Attack(attacker, target);
            image.Idle();

        }

    }
}
