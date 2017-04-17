using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    public interface IItem
    {
        int Level { get; set; }
        ItemType Type { get; set; }
        double Speed { get; set; }
        int Damage { get; set; }
        double ChanceToHit { get; set; }
        int PurchaseCost { get; set; }
        int SellbyCost { get; set; }
        double strengthBoost { get; set; }
        double agilityBoost { get; set; }
        double intellectBoost { get; set; }
    }
}
