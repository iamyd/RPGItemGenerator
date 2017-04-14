using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    class StatsCalculator
    {
        public StatsCalculator()
        {

        }

        public static int GetLevel(Random r)
        {
            return r.Next(0, 10);
        }

        public static double GetAttackSpeed(Random r)
        {
            return r.NextDouble() * (2.0 - 0.5) + 0.5;
        }

        public static double GetChanceToHit(int Level, ItemType Type)
        {
            return 0.9 + Level * 0.05;
        }

        public static int GetDamage(int Level, ItemType Type, Random r)
        {
            int damage = r.Next(5, 9) * Level;
            if(damage <= 0)
            {
                return 1;
            }
            return damage;
        }

        public static double GetDamagePerSecond(int Damage, double ChanceToHit, double Speed)
        {
            return Damage * ChanceToHit * Speed;
        }

        public static double GetBoostChance(int Level)
        {
            return Level * 0.08;
        }

        public static double GetBoostAmount(int Level, Random r)
        {
            return (Level / 2) * r.Next(1, 4);
        }

        public static int GetPurchaseCost(int Level, double DamagePerSecond, double StatsBonuses)
        {
            int price = (int)((Level * DamagePerSecond) + (Level * StatsBonuses)) * 100;
            if (price <= 0)
            {
                return 100;
            }
            return price;
        }

        public static int GetSellbyCost(int PurchaseCost, Random r)
        {
            return (int)(PurchaseCost * r.Next(2, 5))/10;
        }

        public static double GetStrengthBoost(double BoostChance, double BoostAmount, Random r)
        {
            if(r.NextDouble() <= BoostChance)
            {
                return BoostAmount;
            }
            else
            {
                return 0;
            }
        }
        public static double GetAgilityBoost(double BoostChance, double BoostAmount, Random r)
        {
            if (r.NextDouble() <= BoostChance)
            {
                return BoostAmount;
            }
            else
            {
                return 0;
            }
        }
        public static double GetIntellectBoost(double BoostChance, double BoostAmount, Random r)
        {
            if (r.NextDouble() <= BoostChance)
            {
                return BoostAmount;
            }
            else
            {
                return 0;
            }
        }

        public static string GetQuality(int Level)
        {
            if (Level >= 2 && Level < 6)
            {
                return "Mighty";
            }
            else if (Level >= 6 && Level < 10)
            {
                return "Rugged";
            }
            else if (Level == 10)
            {
                return "Legendary";
            }
            else
            {
                return "Common";
            }
        }

        public static string Getsuffix(double strengthBoost, double agilityBoost, double intellectBoost)
        {
            double max3 = Math.Max(strengthBoost, Math.Max(agilityBoost, intellectBoost));
            if (max3 != 0)
            {
                if (max3 == strengthBoost)
                {
                    return "of Strength";
                }
                else if (max3 == agilityBoost)
                {
                    return "of Agility";
                }
                else
                {
                    return "of Intellect";
                }
            }
            else
            {
                return "";
            }
        }
    }
}