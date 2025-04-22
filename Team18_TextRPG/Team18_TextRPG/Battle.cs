using System;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace Sparta_Team18_TextRPG
{
    public class MonsterFactory
    {
        private static Random random = new Random();
        private static List<Monster> monsters = new List<Monster>();

        private static Dictionary<string, (int minHealth, int maxHealth, int minAttack, int maxAttack)> monsterStats =
        new Dictionary<string, (int, int, int, int)>
        {
            { "  슬라임  ", (30, 50, 5, 15) },
            { "  고블린  ", (40, 60, 10, 20) },
            { "   좀비   ", (50, 70, 15, 25) },
            { " 스켈레톤 ", (50, 80, 10, 17) },
            { "   늑대   ", (60, 80, 20, 30) },
            { "   거미   ", (70, 100, 15, 25) },
            { "   트롤   ", (80, 120, 20, 35) },
            { "   오크   ", (80, 130, 15, 25) },
            { "  사냥꾼  ", (50, 80, 15, 25) },
            { "  암살자  ", (50, 80, 15, 25) },
            { " 흑마법사 ", (70, 110, 20, 30) },
        };

        public static List<Monster> GetOrCreateMonsters()
        {
            if (monsters.Count == 0) // 기존 몬스터 리스트가 비어 있을 때만 생성
            {
                int monsterCount = random.Next(1, 5);
                List<string> monsterNames = new List<string>(monsterStats.Keys);

                for (int i = 0; i < monsterCount; i++)
                {
                    string name = monsterNames[random.Next(monsterNames.Count)];
                    var stats = monsterStats[name];

                    int health = random.Next(stats.minHealth, stats.maxHealth + 1);
                    int attack = random.Next(stats.minAttack, stats.maxAttack + 1);

                    monsters.Add(new Monster(name, health, attack, MonsterStatus.Normal));
                }
            }
            return monsters;
        }

        public static void ClearMonsters()
        {
            monsters.Clear();
        }
    }

    public class Battle
    {
        Player player = new Player();
        MainMenu mainMenu = new MainMenu();
        private List<Monster> monsters = new List<Monster>();

        public void PlayerInfo()
        {
            Console.WriteLine("\n+================================+\n");
            Console.WriteLine("[내 정보]\n");
            Console.Write($"Lv. {player.PlayerLevel} ");
            Console.Write($"이름: {player.Name} ");
            Console.WriteLine($"({player.ClassCode})\n");
            Console.WriteLine($"체력: {player.Health}\n");
            Console.WriteLine("+--------------------------------+\n");
        }
        public void BattleStart()
        {
            
            Console.Clear();
            monsters = MonsterFactory.GetOrCreateMonsters();
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"- {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
            }
            PlayerInfo();
            Console.WriteLine("전투 개시");
            Console.WriteLine("전투를 시작합니다.");
            
            
            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 도망가기");
            Console.Write(">> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    MonsterFactory.GetOrCreateMonsters();
                    // 기존 몬스터 유지
                    Combat();
                    break;
                case "2":
                    Console.WriteLine("도망쳤습니다. 다시 마을로 돌아갑니다.");
                    Console.ReadLine();
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    BattleStart();
                    break;
            }
        }

        private void Combat()
        {
            Console.Clear();
            Console.WriteLine($"\n총 {monsters.Count}마리의 몬스터가 등장!\n");
            while (monsters.Count > 0)
            {
                Console.Clear();
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
                }
                PlayerInfo();
                Console.WriteLine("공격할 몬스터를 선택하세요!");
                Console.WriteLine("0.도망가기");
                Console.Write(">> ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int monsterIndex) && monsterIndex >= 1 && monsterIndex <= monsters.Count)
                {
                    Monster target = monsters[monsterIndex - 1];

                    Console.WriteLine($"{target.Name}에게 공격!");
                    target.Health -= 10;

                    if (target.Health <= 0)
                    {
                        Console.WriteLine($"{target.Name}을(를) 처치했다!");
                        monsters.RemoveAt(monsterIndex - 1);
                    }
                }

                if (input == "0")
                {
                    Console.WriteLine("도망쳤습니다. 다시 마을로 돌아갑니다.");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("\n계속 진행하려면 Enter를 누르세요.");
                Console.ReadLine();
            }

            Console.WriteLine("모든 적을 처치했습니다! 마을로 돌아갑니다.");
            MonsterFactory.ClearMonsters(); //  전투 종료 후 리스트 비우기
            Console.ReadLine();
        }

    }
}




