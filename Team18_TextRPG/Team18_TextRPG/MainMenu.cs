using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Team18_TextRPG
{
    public class MainMenu
    {// 완전 신나

        public void Nickname()
        {
            Status status = new Status();//상태창 스크립트 연결 필요###########################################상태창 스크립트 클래스 이름 Status에 덮어씌우기
            Battle battle = new Battle();//전투창 스크립트 연결 필요###########################################전투창 스크립트 클래스 이름 Battle에 덮어씌우기
            Console.Clear();
            string StartAnswer;

            do
            {

                Console.Write(@"스파르타 던전에 오신 여러분 환영합니다.");
                Console.Write("이제 전투를 시작할 수 있습니다.");

                Console.WriteLine("1.상태보기");
                Console.WriteLine("2.전투시작");

                Console.WriteLine("원하시는 행동을 입력해주세요");

                Console.WriteLine(">> ");

                StartAnswer = Console.ReadLine();

                switch (StartAnswer)
                {
                    case "1":
                        //상태창 로직
                        status.ShowStat();//###########################################상태창 스크립트 함수 이름 DisplayStatusmenu에 덮어씌우기
                        break;
                    case "2":
                        // 전투시작 로직
                        battle.BattleScene();//###########################################전투창 스크립트 함수 이름 DisplayBattleMenu에 덮어씌우기
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.\n\n\n");
                        break;
                }

            } while (StartAnswer != "1" || StartAnswer != "2");
        }

        public void DisplayMainMenu()
        {
            string CheckAnswer;
            string NameAnswer;
            Console.Write("스파르타 던전에 오신 여러분 환영합니다.\n");
            Console.Write("원하시는 이름을 설정해 주세요.\n");
            Console.Write(">>");
            NameAnswer = Console.ReadLine();
            Console.Write($"({NameAnswer}) 이 이름으로 하시겠습니까?\n\n1.확정\n2.취소 \n >>");
            CheckAnswer = Console.ReadLine();
            


        }
    }
}
