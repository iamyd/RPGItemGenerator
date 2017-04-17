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
        public double strengthBoost { get; set; }
        public double agilityBoost { get; set; }
        public double intellectBoost { get; set; }

        public string name;
        private string baseName;
        private string suffix;
        private double damagePerSecond;
        private double boostChance;
        private double boostAmount;
        private string quality;
        public Random r = new Random();

        public Item(string baseName, ItemType Type)
        {
            this.baseName = baseName;
            this.Type = Type;

            init();
        }
        private void init()
        {
            this.Level = StatsCalculator.GetLevel(r);
            this.quality = StatsCalculator.GetQuality(Level);
            this.Speed = StatsCalculator.GetAttackSpeed(r);
            this.ChanceToHit = StatsCalculator.GetChanceToHit(Level, Type);
            this.Damage = StatsCalculator.GetDamage(Level, Type, r);
            this.damagePerSecond = StatsCalculator.GetDamagePerSecond(Damage, ChanceToHit, Speed);

            this.boostChance = StatsCalculator.GetBoostChance(Level);
            this.boostAmount = StatsCalculator.GetBoostAmount(Level, r);
            this.strengthBoost = StatsCalculator.GetStrengthBoost(boostChance, boostAmount, r);
            this.agilityBoost = StatsCalculator.GetAgilityBoost(boostChance, boostAmount, r);
            this.intellectBoost = StatsCalculator.GetIntellectBoost(boostChance, boostAmount, r);

            this.PurchaseCost = StatsCalculator.GetPurchaseCost(Level, damagePerSecond, boostAmount);
            this.SellbyCost = StatsCalculator.GetSellbyCost(PurchaseCost, r);
            this.suffix = StatsCalculator.Getsuffix(strengthBoost, agilityBoost, intellectBoost);

            this.name = string.Format("{0} {1} {2}", quality, baseName, suffix);
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
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nPurchase Price: {4} Selling Price: {5}\n", name, Level.ToString(), quality.ToString(),
                Type.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }
        
        private string printArmor()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nArmor: {4}\nStrength Boost: {5}   Agility Boost: {6}   Intellect Boost: {7} \nPurchase Price: {8}   Selling Price: {9}\n", name, Level.ToString(), quality.ToString(),
                Type.ToString(), Damage.ToString(), strengthBoost.ToString(), agilityBoost.ToString(), intellectBoost.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

        private string printWeapon()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nDamage: {4}   Damage Per Second: {5}\nStrength Boost: {6}   Agility Boost: {7}   Intellect Boost: {8} \nPurchase Price: {9}   Selling Price: {10}\n", name, Level.ToString(), quality.ToString(),
                Type.ToString(), Damage.ToString(), damagePerSecond.ToString("#.##"), strengthBoost.ToString(), agilityBoost.ToString(), intellectBoost.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

    }
}
