using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    public class Item {

        public static int Level;
        public static ItemType Type;
        public static double Speed;
        public static int Damage;
        public static double ChanceToHit;
        public static int PurchaseCost;
        public static int SellbyCost;
        public static double StrengthBoost;
        public static double AgilityBoost;
        public static double IntellectBoost;
        public static int DodgeDifficulty;

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
            Item.Type = Type;

            Level = StatsCalculator.GetLevel(r);
            quality = StatsCalculator.GetQuality(Level);
            Speed = StatsCalculator.GetAttackSpeed(r);
            ChanceToHit = StatsCalculator.GetChanceToHit(Level, Type);
            Damage = StatsCalculator.GetDamage(Level, Type, r);
            damagePerSecond = StatsCalculator.GetDamagePerSecond(Damage, ChanceToHit, Speed);

            boostChance = StatsCalculator.GetBoostChance(Level);
            boostAmount = StatsCalculator.GetBoostAmount(Level, r);
            StrengthBoost = StatsCalculator.GetStrengthBoost(boostChance, boostAmount, r);
            AgilityBoost = StatsCalculator.GetAgilityBoost(boostChance, boostAmount, r);
            IntellectBoost = StatsCalculator.GetIntellectBoost(boostChance, boostAmount, r);

            PurchaseCost = StatsCalculator.GetPurchaseCost(Level, damagePerSecond, boostAmount);
            SellbyCost = StatsCalculator.GetSellbyCost(PurchaseCost, r);

            DodgeDifficulty = StatsCalculator.GetDodgeDifficulty(Speed);
            this.suffix = StatsCalculator.Getsuffix(StrengthBoost, AgilityBoost, IntellectBoost);
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
                Type.ToString(), Damage.ToString(), StrengthBoost.ToString(), AgilityBoost.ToString(), IntellectBoost.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

        private string printWeapon()
        {
            string retval = string.Format("{0}\nLevel: {1} Quality: {2}\n{3}\nDamage: {4}   Damage Per Second: {5}\nStrength Boost: {6}   Agility Boost: {7}   Intellect Boost: {8} \nPurchase Price: {9}   Selling Price: {10}\n", name, Level.ToString(), quality.ToString(),
                Type.ToString(), Damage.ToString(), damagePerSecond.ToString("#.##"), StrengthBoost.ToString(), AgilityBoost.ToString(), IntellectBoost.ToString(), PurchaseCost.ToString(), SellbyCost.ToString());
            return retval;
        }

    }
}
