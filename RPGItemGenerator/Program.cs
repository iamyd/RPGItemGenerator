using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGItemGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NameLibrary lib = new NameLibrary();
            while (true)
            {

                Item i = null;
                Console.WriteLine("\nPress any key to generate an item, press q to quit.\n");
                char c = Console.ReadKey().KeyChar;
                if (!c.Equals('q'))
                {
                    ItemType type = lib.GetItemType();
                    i =new Item(lib.GetBaseNameForItemType(type), type);
                }
                else
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("\n");
                Console.Write(i);
            }
        }
    }
}