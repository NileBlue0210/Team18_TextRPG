using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    public class MainMenu
    {
        Player player = new Player();

        public MainMenu()
        {

        }

        public void DisplayMainMenu()
        {
            Battle battle = new Battle();

       

            Console.Clear();
            string StartAnswer;

            do
            {

                Console.Clear();
                

                Console.Write(@"스파르타 던전에 오신 여러분 환영합니다.");
                Console.Write("\n이제 전투를 시작할 수 있습니다.");

                Console.WriteLine("\n1.상태보기");
                Console.WriteLine("2.전투시작");
                Console.WriteLine("3.인벤토리");
                Console.WriteLine("4.상점");

                Console.WriteLine("원하시는 행동을 입력해주세요");

                Console.WriteLine(">> ");

                StartAnswer = Console.ReadLine() ?? "";

                switch (StartAnswer)
                {
                    case "1":
                        //상태창 로직
                       
                        new StatusUI().ShowStat();
                        break;
                    case "2":
                        // 전투시작 로직
                        battle.BattleStart();
                        break;

                        case "3":
                        new InventoryUI().ShowInventory();
                        break;

                    case "4":
                        new ShopManager().ShowShop();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.\n\n\n");
                        break;
                }

            } while (StartAnswer != "1" || StartAnswer != "2");
        }

        public void Nickname()
        {
            string checkAnswer;
            string nameAnswer;

            while (true)
            {
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해 주세요.");
                Console.Write(">> ");
                nameAnswer = Console.ReadLine() ?? "";

                while (true)
                {
                    Console.WriteLine($"\n({nameAnswer}) 이 이름으로 하시겠습니까?");
                    Console.WriteLine("1. 확정");
                    Console.WriteLine("2. 취소");
                    Console.Write(">> ");
                    checkAnswer = Console.ReadLine() ?? "";

                    if (checkAnswer == "1")
                    {
                        player.Name = nameAnswer; 
                        Console.WriteLine("이름이 확정되었습니다!");
                        return;
                    }
                    else if (checkAnswer == "2")
                    {
                        Console.WriteLine("이름 설정을 다시 시작합니다.\n");
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 1 또는 2를 입력해주세요.\n");
                    }
                }
            }
        }
    }
}
