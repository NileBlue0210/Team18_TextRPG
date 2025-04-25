using Sparta_Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage(bool isVictory, List<Monster>? monsters)
        {

            ConvertClassCode convertClassCode = new ConvertClassCode();
            string result = isVictory ? "You Victory" : "You Lose";

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("배틀 결과\n\n\n\n\n");
                Console.ResetColor();

                Console.WriteLine("+======================+");
                Console.WriteLine("내 정보\n");
                Console.WriteLine($"{GameManager.Instance.player.Name} ({convertClassCode.ConvertClassCodeToString(GameManager.Instance.player.ClassCode)})");
                Console.WriteLine($"LV:");
                Console.Write($"체력:");
                Console.WriteLine($"골드:");

                //레벨,체력,골드 시간차 표기 연출
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"{result}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 4);
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                Thread.Sleep(1000);
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
                Console.Write("0. ");
                Console.ResetColor();
                Console.Write("다음");
                Console.SetCursorPosition(0, 23);
                monsters.Clear();

                string input = Console.ReadLine();
                switch (input)
                {
                    default:
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.DisplayMainMenu();
                        return;
                }
            }
        }
    }
}
