using Sparta_Team18_TextRPG;
using Team18_TextRPG;
using static Sparta_Team18_TextRPG.EndStageView;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage(bool isVictory, List<Monster>? monsters = null)
        {
            ConvertClassCode convertClassCode = new();
            LoadingView loadingView = new();
            string result = isVictory ? "You Victory" : "You Lose";
            bool inputlock = false;  //키보드 입력 잠금

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0.");
            Console.ResetColor();
            Console.Write("다음");
            inputlock = true;

            while(true)
            {
                if (inputlock == true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == '0')
                    {
                        loadingView.LoadingPage();
                        return;
                    }
                    else 
                    {
                        Console.SetCursorPosition(0, 24);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(0, 24);
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                else { }
            }    
        }
    }

    public class LoadingView()
    {
        public void LoadingPage()
        {
            Random random = new();
            int k = random.Next(comentlist.Count); //배열 크기에 맞는 랜덤숫자

            for (int i = 50; i >= 0; i--)
            {
                Console.SetCursorPosition(i, 0);
                var consolPoint = Console.GetCursorPosition(); // 콘솔 위치를 변수에 저장
                Thread.Sleep(60);
                for (int j = 0; j < 25; j++)
                {
                    Console.SetCursorPosition(consolPoint.Left, j); //콘솔의 x 좌표 + j
                    Console.WriteLine(" ");
                }
            }
            Console.SetCursorPosition(10, 10);
            Thread.Sleep(1000);
            foreach (char tiplist in comentlist[k]) // tiplist 리스트의 k번째 문장을 들고 와서 한글자씩 시간차 입력
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
            Console.WriteLine("로딩 완료");
            Thread.Sleep(2000);
            Program.ChangeView(EViewName.Main);


        }
        public List<string> comentlist = new()
        {
            "마을로 돌아가는 중",
            "구멍난 가방을 메우는 중",
            "골드를 모아서 돌아가는 중",
            "전리품을 챙겨서 돌아가는 중"
        };
    }
}
