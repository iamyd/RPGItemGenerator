using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGItemGenerator;

namespace Du.RPGCore
{
    public class GameConstants
    {

        private int dodgeDifficulty = Item.DodgeDifficulty;
        private int damageRange = 10;
        private int damageBonus = Item.Damage;
        private int playerHitpoints = 500;

        public static GameConstants instance = new GameConstants();

        public GameConstants()
        { 
        }

        public int DamageBonus
        {
            get { return damageBonus; }
        }

        public int DamageRange
        {
            get { return damageRange; }
        }
        public int PlayerHitpoints
        {
            get { return playerHitpoints; }
        }
        public int DodgeDifficulty
        {
            get { return dodgeDifficulty; }
        }
        public static GameConstants Instance
        {
            get { return instance; }
        }
    }
}
