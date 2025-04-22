using Sparta_Team18_TextRPG;

namespace EndStageView
{
    Player player = new Player();
    internal class EndStageView
    {
        static void EndStage()
        {
            Console.WriteLine("배틀 결과\n");
            Console.WriteLine(""); //승리 & 패배, 시간차 주기
            Console.WriteLine("system message\n");
            Console.WriteLine("+==================+");

            Console.WriteLine("내 정보\n");
            Console.WriteLine($"{player.Name}({player.Classcode})");
            Console.WriteLine($체력: {hp}""); //HP 변화량 보여주기?
            Console.WriteLine($"골드: {gold}\n\n"); //골드 변화량 보여주기?
            Console.WriteLine("대상을 선택해주세요>>\n");
            Console.WriteLine("전투옵션\n");
            Console.WriteLine("0.다음");

            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    // 다음 스테이지로 이동하는 코드
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다..");
                    continue;
            }
    }
}
