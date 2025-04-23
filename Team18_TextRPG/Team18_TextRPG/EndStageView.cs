using Sparta_Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage()
        {
            Player player = new Player();
            ConvertClassCode convertClassCode = new ConvertClassCode();
            string result = "";

            if (player.Health <= 0)
            {
                result = "패배...";
            }
            else if (player.Health > 0) // 플레이어 체력이 0보다 높을 때 && 몬스터 수가 0일 때
            {
                result = "승리!";
            }

            while (true)
            {
                Console.WriteLine("배틀 결과\n\n\n\n\n");
                Console.WriteLine("+======================+");
                Console.WriteLine("내 정보\n");
                Console.WriteLine($"LV.{player.PlayerLevel} {player.Name} ({convertClassCode.ConvertClassCodeToString(player.ClassCode)})");
                Console.WriteLine($"LV:");
                Console.Write($"체력:");                //원래 체력 -> player.Health
                Console.WriteLine($"골드:");            //원래 골드 -> player.Gold
                Console.WriteLine("대상을 선택해주세요>>\n");
                Console.WriteLine("-전투옵션-");
                Console.WriteLine("0.다음");

                Console.WriteLine($"{result}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 3);
                Console.Write($"{player.Health}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(5, 11);
                Console.Write($"{player.Gold}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(5, 12);


                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        MainMenu main = new MainMenu();
                        main.DisplayMainMenu();
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다..");
                        continue;
                }
            }
        }
    }
}
