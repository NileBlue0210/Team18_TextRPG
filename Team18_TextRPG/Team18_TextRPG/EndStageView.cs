using Sparta_Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    internal class EndStageView
    {
        static void EndStage()
        {
            while (true)
            {
                Player player = new Player();
                ConvertClassCode convertClassCode = new ConvertClassCode();

                Console.WriteLine("배틀 결과\n");
                Console.WriteLine(""); //승리 & 패배, 시간차 주기
                Console.WriteLine("system message\n");
                Console.WriteLine("+==================+");

                Console.WriteLine("내 정보\n");
                Console.WriteLine($"{player.Name}({convertClassCode.ConvertClassCodeToString(player.ClassCode)})");
                Console.WriteLine($"체력: {player.Health}");
                Console.WriteLine($"골드: {player.Gold}\n\n");
                Console.WriteLine("대상을 선택해주세요>>\n");
                Console.WriteLine("전투옵션\n");
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
