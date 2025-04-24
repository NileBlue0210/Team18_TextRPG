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
        public MainMenu()
        {

        }

        public void DisplayMainMenu()
        {
            Console.Clear();

            string StartAnswer;
            InputValidator inputValidator = new InputValidator();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");

            // 플레이어의 닉네임이 정해져 있지 않을 경우, 닉네임 설정 실행
            if (inputValidator.CheckEmptyInput(GameManager.Instance.player.Name))
            {
                SetNickName();
            }

            while (true)
            {
                Console.Clear();
                Console.Write("\n");
                Console.Write("이제 전투를 시작할 수 있습니다.");
                Console.Write("\n");
                Console.WriteLine("1.상태보기");
                Console.WriteLine("2.전투시작");
                Console.WriteLine("3.인벤토리");
                Console.WriteLine("4.상점");

                GameManager.Instance.Ask();

                StartAnswer = Console.ReadLine() ?? "";

                switch (StartAnswer)
                {
                    case "1":
                        //상태창 로직
                        Program.ChangeView(EViewName.Status);
                        break;
                    case "2":
                        // 전투시작 로직
                        Program.ChangeView(EViewName.Battle);
                        break;
                    case "3":
                        // 인벤토리 로직
                        Program.ChangeView(EViewName.Inventory);
                        break;
                    case "4":
                        // 상점 로직
                        Program.ChangeView(EViewName.Shop);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        continue;
                }
            }
        }

        static void SetNickName()
        {
            InputValidator inputValidator = new InputValidator();

            string checkAnswer;
            string nameAnswer;
            string defaultName = "이름없는 용사";   // 유저가 이름을 입력하지 않았을 때의 디폴트 네임

            while (true)
            {
                Console.WriteLine("원하시는 이름을 설정해 주세요.");
                Console.Write(">> ");

                nameAnswer = Console.ReadLine();

                if(inputValidator.CheckEmptyInput(nameAnswer))
                {
                    Console.Write("이름을 입력하시지 않으면 자동으로");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {defaultName}");
                    Console.ResetColor();
                    Console.Write("로 이름이 설정됩니다.");
                    nameAnswer = defaultName;
                }

                while (true)
                {
                    Console.Write("\n");
                    Console.Write($"(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {nameAnswer} ");
                    Console.ResetColor();
                    Console.WriteLine(") 이 이름으로 하시겠습니까?");
                    Console.WriteLine("1. 확정");
                    Console.WriteLine("2. 취소");
                    Console.Write(">> ");
                    checkAnswer = Console.ReadLine() ?? "";

                    if (checkAnswer == "1")
                    {
                        GameManager.Instance.player.Name = nameAnswer; 
                        return;
                    }
                    else if (checkAnswer == "2")
                    {
                        nameAnswer = "";
                        Console.WriteLine("이름 설정을 다시 시작합니다.\n");
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 확정, 또는 취소를 선택해주세요.\n");
                    }
                }
            }
        }
    }
}
