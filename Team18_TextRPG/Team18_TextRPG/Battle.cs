using System;

namespace Sparta_Team18_TextRPG
{
    enum MonsterType
    {
        Goblin = 1,
        Orc,
        Troll,
        Dragon
    }

    public class Battle
    {
        Player player = new Player();
       
        public void PlayerInfo()
        {
            Console.WriteLine("[내 정보]\n");
            Console.Write($"Lv. {player.PlayerLevel} ");
            Console.Write($"이름: {player.Name} ");
            Console.WriteLine($"({player.ClassCode})\n");
            Console.WriteLine($"체력: {player.Health}\n");
        }
        public void BattleMenu()
        {
            Console.WriteLine("1. 공격!");
            Console.WriteLine("0. 나가기");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":

                    ShowAttackScene();
                    break;
                case "0":

                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    Console.ReadLine();
                    break;
            }
        }

        public void BattleScene()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("전투 돌입!!\n");

                Console.WriteLine("적 1");
                Console.WriteLine("적 2\n");
                // 적 정보 출력: 적의 이름, 체력
                // 무작위 적 생성: 1 ~ 4

                Console.WriteLine("+================================+\n");

                //캐릭터 정보 출력: 캐릭터 이름, 레벨, 직업, 체력
                PlayerInfo();

                Console.WriteLine("+--------------------------------+\n");

                BattleMenu();

            }
        }

        public void ShowAttackScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("적 - 공격대상 선택하는 씬\n");
                //적 무작위 출현 로직 구현해야 함.
                Console.WriteLine("1. 적 1");
                Console.WriteLine("2. 적 2\n");
                Console.WriteLine("+================================+\n");
                PlayerInfo();

                Console.WriteLine("+--------------------------------+\n");
                Console.WriteLine("1~4. 대상 선택");
                Console.WriteLine("0. 취소");
                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "0":
                        
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }

    static void BattleEnd()
    {
        gold +=
        Console.Clear();
        Console.WriteLine("배틀 결과\n");
        Console.WriteLine(""); //승리 & 패배, 시간차 주기
        Console.WriteLine("system message\n");
        Console.WriteLine("+==================+");

        Console.WriteLine("내 정보\n");
        Console.WriteLine($"{player.Name} ({player.Classcode})");
        Console.WriteLine($"체력: {player.Health}"); //HP 변화량 보여주기?
        Console.WriteLine($"{player.Gold}""\n\n"); //골드 변화량 보여주기?
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

