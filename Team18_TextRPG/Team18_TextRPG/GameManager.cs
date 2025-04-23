using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Sparta_Team18_TextRPG
{
    public class GameManager
    {
        Player player = new Player();

        static void Main()
        {
            Player player = new Player();
            MainMenu mainMenu = new MainMenu(player);

            mainMenu.Nickname();
            mainMenu.DisplayMainMenu();
            
            Status status = new Status(player);
            status.ShowStat();
        }

        public void GameOver()
        {
            Console.WriteLine($"게임 오버. {player.Name}이 쓰러졌습니다.");
        }
    }
}
