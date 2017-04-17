using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Du.RoleplayingGameInterfaces;
using Du.RPGCore;
using RPGItemGenerator;

namespace WPFBattle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CombatThread combatThread;
        private TextBoxStreamWriter consoleWriter;
        IList<ICharacter> playerParty = new List<ICharacter>();
        IList<ICharacter> enemyParty = new List<ICharacter>();
        NameLibrary l = new NameLibrary();

        public MainWindow()
        {
            InitializeComponent();

            consoleWriter = new TextBoxStreamWriter(output);
            Console.SetOut(consoleWriter);

            Item i = new Item(l.GetBaseNameForItemType(ItemType.RangedWeapon), ItemType.RangedWeapon);

            ICharacter player1 = new WarriorSubclass("Riku", Riku);

            playerParty.Add(player1);

            ICharacter enemy1 = new MageSubclass("Flare", Flare);

            enemyParty.Add(enemy1);

            ICharacter enemy2 = new MageSubclass("Vexen", Vexen);
            enemyParty.Add(enemy2);

            ICharacter enemy3 = new MageSubclass("Xenmas", Xenmas);
            enemyParty.Add(enemy3);

            ICombat combat = new Combat(playerParty, enemyParty, "Riku", "BadGuys");

            combatThread = new CombatThread(combat);
            combatThread.Start();
         }
        //}

        private void Console_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
