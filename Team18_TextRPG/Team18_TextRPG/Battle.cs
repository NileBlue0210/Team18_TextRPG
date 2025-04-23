using System;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_Team18_TextRPG
{
    public class MonsterFactory
    {
        private static Random random = new Random();
        private static List<Monster> monsters = new List<Monster>();

        private static Dictionary<string, (int minHealth, int maxHealth, int minAttack, int maxAttack)> monsterStats =
        new Dictionary<string, (int, int, int, int)>
        {
            { "  슬라임  ", (10, 20, 3, 8) },
            { "  고블린  ", (15, 25, 10, 20) },
            { "   좀비   ", (16, 26, 3, 25) },
            { " 스켈레톤 ", (30, 45, 10, 12) },
            { "   늑대   ", (35, 60, 12, 15) },
            { "   거미   ", (20, 27, 3, 13) },
            { "   트롤   ", (80, 120, 20, 35) },
            { "   오크   ", (40, 50, 15, 25) },
            { "  사냥꾼  ", (35, 50, 22, 27) },
            { "  암살자  ", (23, 34, 12, 37) },
            { " 흑마법사 ", (17, 29, 33, 40) },
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
        private List<Monster> monsters = new List<Monster>();

        public Battle(Player player)
        {
            this.player = player;
        }

        public void BattleStart()
        {
            
            Console.Clear();
            monsters = MonsterFactory.GetOrCreateMonsters();
            Console.WriteLine("\n[적 무리]\n");
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"- {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
            }

            player.ShowPlayerInfo();

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

            Phase turnManager = new Phase();

            // turnManager.PlayerTurn(player, monsters);
            PlayerTurn(player, monsters);
        }

        private void PlayerTurn(Player player, List<Monster> monsters)
        {
            string userInput = "";
            InputValidator inputValidator = new InputValidator();   // 플레이어 입력 유효성 검사 클래스

            Console.WriteLine($"\n총 {monsters.Count}마리의 몬스터가 등장!\n");

            while (monsters.Count > 0 && player.Health > 0) //플레이어 체력 0보다 크면 행동
            {
                Console.Clear();
                Console.WriteLine("\n[적 무리]\n");

                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
                }
                if (monsters.Count == 0)
                {
                    BattleEnd();
                }

                player.ShowPlayerInfo();

                Console.WriteLine("공격할 몬스터를 선택하세요!");
                Console.WriteLine("0.도망가기");
                Console.Write(">> ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Write("도망쳤습니다. 다시 마을로 돌아갑니다.");
                        Console.ReadLine();
                        return;

                    default:
                        if (int.TryParse(userInput, out int monsterIndex) && monsterIndex >= 1 && monsterIndex <= monsters.Count)
                        {
                            Monster target = monsters[monsterIndex - 1];

                            int battleDamage = player.PlayerAttack(target);

                            target.Health -= battleDamage;

                            Console.WriteLine($"{target.Name}에게 공격!");

                            // 몬스터 처치 시 사망 처리, 아닐 경우 데미지 계산
                            if (target.Health <= 0)
                            {
                                target.Health = 0; // 체력이 음수라도 0으로 고정
                                target.MonsterDie(target);

                                Console.WriteLine($"{target.Name}(을)를 처치했습니다.");

                                monsters.RemoveAt(monsterIndex - 1);
                            }

                            MonsterAttack();
                        }
                        break;
                }
                Console.WriteLine("\n계속 진행하려면 Enter를 누르세요.");
                Console.ReadLine();
            }
        }

        private void MonsterAttack()
        {
            Console.WriteLine($"\n몬스터들의 반격!\n");
            foreach (Monster monster in monsters)
            {
                if (player.Health <= 0) break;

                int damage = (int)monster.Attack;
                player.Health -= damage;
                Console.WriteLine($"적: {monster.Name} 공격! | -{damage} 피해!");
                Console.WriteLine($"플레이어 남은 체력: {player.Health}");
            }
            if (player.Health <= 0)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                //몬스터 상태 변화()
            }
        }

        public void BattleEnd()
        {
            //전투 결과 출력 구현부
            Console.WriteLine("모든 적을 처치했습니다! 마을로 돌아갑니다.");
            MonsterFactory.ClearMonsters(); //  전투 종료 후 리스트 비우기
            Console.ReadLine();
        }
    }
}




