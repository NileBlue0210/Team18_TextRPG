using Sparta_Team18_TextRPG;
using Team18_TextRPG;
using static Sparta_Team18_TextRPG.EndStageView;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage(bool isVictory, List<Monster> ?monsters = null)
        {
            ConvertClassCode convertClassCode = new();
            LoadingView loadingView = new();
            string result = isVictory ? "You Victory" : "You Lose";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("배틀 결과\n\n\n\n\n");
            Console.ResetColor();

            Console.WriteLine("+======================+");
            Console.WriteLine("내 정보\n");
            Console.WriteLine($"{GameManager.Instance.player.Name} ({convertClassCode.ConvertClassCodeToString(GameManager.Instance.player.ClassCode)})");
            Console.WriteLine($"LV:");
            Console.WriteLine($"체력:");
            Console.WriteLine($"골드:");

            //결과, 레벨, 체력, 골드 시간차 표기 연출
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine($"{result}");
            Thread.Sleep(1000);

            if (monsters != null)
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(4, 10);
                monsters.Clear();
            }
            else { }

            Console.SetCursorPosition(4, 10);
            Console.WriteLine($"{GameManager.Instance.player.PlayerLevel}");
            Thread.Sleep(1000);
            Console.SetCursorPosition(6, 11);
            Console.Write($"{GameManager.Instance.player.Health}");
            Thread.Sleep(1000);
            Console.SetCursorPosition(6, 12);
            Console.Write($"{GameManager.Instance.player.Gold}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 17);

            Thread.Sleep(1000);
            Console.WriteLine("\n대상을 선택해주세요>>\n");
            Console.WriteLine("-전투옵션-");
            Thread.Sleep(1300);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0.");
            Console.ResetColor();
            Console.Write("다음");
            Console.SetCursorPosition(0, 23);

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == '0')
            {
                loadingView.ShowTip(); //로딩화면
                Thread.Sleep(3000);
                Console.ReadLine();
                Program.ChangeView(EViewName.Main);
            }
            else
            {
                 Console.WriteLine("잘못된 입력입니다.");
            }

        }
    }

    public class LoadingView()
    {
        public void ShowTip()
        {
            var tiplists = tiplist;
            Random random = new();
            int k = random.Next(tiplist.Count); //배열 크기에 맞는 랜덤숫자

            for (int i = 50; i >= 0; i--)
            {
                Console.SetCursorPosition(i, 0);
                var consolPoint = Console.GetCursorPosition(); // 콘솔 위치를 변수에 저장
                Thread.Sleep(60);
                for (int j = 0; j < 23; j++)
                {
                    Console.SetCursorPosition(consolPoint.Left, j); //콘솔의 마지막 x, y 좌표를 불러옴
                    Console.WriteLine(" ");
                }
            }
            Console.SetCursorPosition(10, 10);
            Thread.Sleep(1000);
            foreach (char tiplist in tiplist[k]) // tiplist 리스트의 k번째 문장을 들고 와서 한글자씩 시간차 입력
            {
                Console.Write(tiplist);
                Thread.Sleep(100);
            }
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(2000);
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("아무 키나 눌러서 진행");
        }

        public List<string> tiplist = new()
        {
            "전투 시작 전 체력을 확인하세요",
            "공격력이 높은 적을 먼저 처치하는 것이 좋습니다",
            "도망쳐도 괜찮습니다",
            $"{GameManager.Instance.player.Name}, 포션 챙겨요"
        };

    }

}
