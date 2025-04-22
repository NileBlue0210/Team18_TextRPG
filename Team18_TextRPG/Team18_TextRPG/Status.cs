using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_Team18_TextRPG; 

namespace Sparta_Team18_TextRPG
{
    class Status
    {
        Player player = new Player();
        ConvertClassCode convertClassCode = new ConvertClassCode();
        MainMenu mainMenu = new MainMenu();


        public void ShowStat()
        {
            string className = convertClassCode.ConvertClassCodeToString(player.ClassCode);
            string goToMainMenu = "";
            
            do
                
            {
                Console.Clear();

                Console.WriteLine(" [상태보기] ");
                Console.WriteLine("\n 캐릭터의 정보가 표시됩니다. ");
                Console.WriteLine($"\n +=========================+");
                Console.WriteLine($"\n Lv. {player.PlayerLevel}");
                Console.WriteLine($" Chad ( {className} )");
                Console.WriteLine($" 공격력 : {player.Attack}");
                Console.WriteLine($" 방어력 : {player.Defense}");
                Console.WriteLine($" 체 력 : {player.Health}");
                Console.WriteLine($" Gold : {player.Gold}");

                Console.WriteLine("\n0. 나가기");

                
               
                goToMainMenu = Console.ReadLine();

                switch (goToMainMenu)
                {
                    case "0":
                        mainMenu.DisplayMainMenu();
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 확인 후 다시 입력해주세요.\n\n\n");
                        Console.ReadKey();// 이건 잠깐 멈춰! 해주는거
                        break;
                }

            } while (goToMainMenu != "0");

        }
    }
}
