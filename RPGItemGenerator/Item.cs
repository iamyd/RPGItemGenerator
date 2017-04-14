using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    public class Item : IItem
    {
        public int Level { get; set; }
        public ItemType Type { get; set; }
        public double Speed { get; set; }
        public int Damage { get; set; }
        public double ChanceToHit { get; set; }
        public int PurchaseCost { get; set; }
        public int SellbyCost { get; set; }

        public string name;
        private string baseName;
        private string suffix;
        private double DamagePerSecond;
        private double BoostChance;
        private double BoostAmount;
        private string Quality;
        public Random r = new Random();

        public Item(string baseName, ItemType Type)
        {
            this.baseName = baseName;
            this.Type = Type;

            init();
        }
        private void init()
        {
            this.Level = StatsCalculator.getLevel(r);
            this.Speed = StatsCalculator.getArrackSpeed(r);
            this.ChanceToHit = StatsCalculator.getChanceToHit(Level, Type);
            this.Damage = StatsCalculator.getDamage(Level, Type, r);
            this.DamagePerSecond = StatsCalculator.getDamagePerSecond(Damage, ChanceToHit, Speed);
            this.BoostChance = StatsCalculator.getBoostChance(Level);
            this.BoostAmount = StatsCalculator.getBoostAmount(Level, r);
            this.PurchaseCost = StatsCalculator.getPurchaseCost(Level, DamagePerSecond, BoostAmount);
            this.SellbyCost = StatsCalculator.getSellbyCost(PurchaseCost, r);
            this.Quality = StatsCalculator.getQuality(Level);

            this.name = string.Format("{0} {1}", Quality, baseName);
        }

        public override string ToString()
        {
            switch (Type)
            {
                case ItemType.HeadArmor:
                case ItemType.ChestArmor:
                case ItemType.FeetArmor:
                    return printArmor();
                case ItemType.MeleeWeapon:
                case ItemType.RangedWeapon:
                case ItemType.MagicWeapon:
                    return printWeapon();
                default:
                    return printItem();
            }
        }

        private string printItem()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nPurchase Price: {4} Selling Price: {5}\n", name, Level.ToString(), Quality.ToString(),
                Type.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }
        
        private string printArmor()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nArmor: {4}\nPurchase Price: {5} Selling Price: {6}\n", name, Level.ToString(), Quality.ToString(),
                Type.ToString(), Damage.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

        private string printWeapon()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nDamage: {4} Damage Per Second: {5}\nPurchase Price: {6} Selling Price: {7}\n", name, Level.ToString(), Quality.ToString(),
                Type.ToString(), Damage.ToString(), DamagePerSecond.ToString("#.##"), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

    }
}
