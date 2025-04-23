using Sparta_Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage(Player player)
        {
            ConvertClassCode convertClassCode = new ConvertClassCode();
            string result;

            if (player.Health <= 0)  // 승리 & 패배
            {
                result = "패배...";
            }
            else if (player.Health > 0) // 플레이어 체력이 0보다 높을 때 && 몬스터 수가 0일 때
            {
                result = "승리!";
            }

            while (true)
            {

                Console.WriteLine("배틀 결과\n");
                Console.WriteLine($"{result}");
                Console.WriteLine("system message\n");
                Console.WriteLine("+======================+");
                Console.WriteLine("내 정보\n");
                Console.WriteLine($"{player.Name} ({convertClassCode.ConvertClassCodeToString(player.ClassCode)})");
                Console.WriteLine($"체력: {player.Health}");                                                                   // 시간차 구현(승리,패배 -> 바뀐 체력 -> 바뀐 골드)
                Console.WriteLine($"골드: {player.Gold}\n\n");
                Console.WriteLine("대상을 선택해주세요>>\n");
                Console.WriteLine("-전투옵션-");
                Console.WriteLine("0.다음");

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
