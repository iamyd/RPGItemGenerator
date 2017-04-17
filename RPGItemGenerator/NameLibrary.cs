using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    public class NameLibrary
    {
        public Dictionary<ItemType, List<string>> nameDictionary = new Dictionary<ItemType, List<string>>();

        public Random r;

        public NameLibrary()
        {
            r = new Random();
            fillWeapons();
            fillArmor();
        }

        private void fillWeapons()
        {
            List<string> meleeWeaponList = new List<string>(){
                "Shiv",
                "Dagger",
                "Knife",
                "Spike",
                "Blade",
                "Kukri",
                "Sword",
                "Hatchet",
                "Axe",
                "Pick",
                "Poker",
                "Spear",
                "Glaive",
                "Knuckles",
                "Club",
                "Beater",
                "Stick",
                "Prod",
                "Claymore",
                "Hammer",
                "Longsword",
                "Greatsword",
                "Waraxe"};

            nameDictionary.Add(ItemType.MeleeWeapon, meleeWeaponList);

            List<string> magicWeaponList = new List<string>() {
                "DoomwardNimble",
                "Lifebinder",
                "Doomward",
                "Nimble",
                "Thunderstorm Aspect",
                "Apostle",
                "Deathsong",
                "Earthshadow",
                "Illumina",
                "Fortune's Beacon"
            };
            nameDictionary.Add(ItemType.MagicWeapon, magicWeaponList);

            List<string> rangedWeaponList = new List<string>(){
                "Bowcaster",
                "Crossbow",
                "Bow",
                "Longbow",
                "Repeater",
                "Launcher",
                "Flinger",
                "Sling",
                "Sling-staff",
                "Atl-latl",
                "Pistol",
                "Gun",
                "Blaster",
                "Musket",
                "Carbine",
                "Blunderbuss",
                "Cannon",
                "Rifle",  };
            nameDictionary.Add(ItemType.RangedWeapon, rangedWeaponList);
        }

        private void fillArmor()
        {
            List<string> headList = new List<string>(){
                "Cap",
                "Helm",
                "Helmet",
                "Mask",
                "Goggles"
                };
            nameDictionary.Add(ItemType.HeadArmor, headList);

            List<string> chestList = new List<string>(){
                "Shirt",
                "Jacket",
                "Suit",
                "Bolster",
                "Armor",
                "Skinsuit",
                "Parka",
                "Shell"};
            nameDictionary.Add(ItemType.ChestArmor, chestList);

            List<string> feetList = new List<string>(){
                "Gaitors",
                "Greives",
                "Boots",
                "Shoes",
                "Stompers"};
            nameDictionary.Add(ItemType.FeetArmor, feetList);
        }
        public T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(r.Next(v.Length));
        }

        public ItemType GetItemType()
        {
            return RandomEnumValue<ItemType>();
        }

        public string GetBaseNameForItemType(ItemType type)
        {
            var itemList = nameDictionary[type];
            return itemList[r.Next(itemList.Count)];
        }
    }
}
