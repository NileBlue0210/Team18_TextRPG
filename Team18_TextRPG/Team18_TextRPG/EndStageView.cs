using Sparta_Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    public class EndStageView
    {
        public void EndStage(Player player)
        {
            ConvertClassCode convertClassCode = new ConvertClassCode();
            string result = "";

            if (player.Health > 0)
            {
                result = "You Victory";
            }
            else if (player.Health <= 0)
            {
                result = "You Lose";
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("배틀 결과\n\n\n\n\n");
                Console.ResetColor();

                Console.WriteLine("+======================+");
                Console.WriteLine("내 정보\n");
                Console.WriteLine($"{player.Name} ({convertClassCode.ConvertClassCodeToString(player.ClassCode)})");
                Console.WriteLine($"LV:");
                Console.Write($"체력:");
                Console.WriteLine($"골드:");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, 3);
                Thread.Sleep(1000);
                Console.WriteLine($"{result}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(4, 8);
                Console.WriteLine($"{player.PlayerLevel}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(6, 9);
                Console.Write($"{player.Health}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(6, 10);
                Console.Write($"{player.Gold}");
                Console.ResetColor();
                Console.SetCursorPosition(0, 17);

                Thread.Sleep(1000);
                Console.WriteLine("\n대상을 선택해주세요>>\n");
                Console.WriteLine("-전투옵션-");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("0.");
                Console.ResetColor();
                Console.Write(" 다음");


                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        MainMenu main = new MainMenu();
                        main.DisplayMainMenu();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다..");
                        continue;
                }
            }
        }
    }
}
