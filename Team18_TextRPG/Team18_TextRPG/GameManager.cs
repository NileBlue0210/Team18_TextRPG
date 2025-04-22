using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Sparta_Team18_TextRPG
{
    internal class GameManager
    {
        static void Main()
        {
            Player player = new Player();
            MainMenu mainMenu = new MainMenu();

            mainMenu.DisplayMainMenu();
            
            Status status = new Status();
            status.ShowStat();
            
        }
    }
}
