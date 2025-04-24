using Sparta_Team18_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team18_TextRPG
{
    internal class Program
    {
        static void Main()
        {
            Player player = new Player();

            MainMenu mainMenu = new MainMenu(player);
            mainMenu.Nickname();
            mainMenu.DisplayMainMenu();

            StatusUI status = new StatusUI(player);
            status.ShowStat();
        }
    }
}
