using System;
using System.Threading;
using System.Xml.Linq;

namespace Sparta_Team18_TextRPG
{
    public class MonsterFactory // 1~4개체 랜덤으로 등장.
    {
        private static Random random = new Random();
        private static List<Monster> monsters = new List<Monster>();
        private static Dictionary<string, (int minHealth, int maxHealth, int minAttack, int maxAttack)> monsterStats = new Dictionary<string, (int, int, int, int)>
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
        public static List<Monster> CreateRandomMonster()
        {
            if (monsters.Count == 0)
            {
                int monsterCount = random.Next(1, 5);
                List<string> monsterNames = new List<string>(monsterStats.Keys);

                for (int i = 0; i < monsterCount; i++)
                {
                    // 몬스터 이름에 따른 스탯
                    string name = monsterNames[random.Next(monsterNames.Count)];
                    var stats = monsterStats[name]; // var: 타입 맞춤.
                                                    // 몬스터 스탯 랜덤 생성
                    int health = random.Next(stats.minHealth, stats.maxHealth + 1);
                    int attack = random.Next(stats.minAttack, stats.maxAttack + 1);

                    monsters.Add(new Monster(name, health, attack, MonsterStatus.Normal));
                }
            }
            return monsters; // 리스트로 monsters 값 반환
        }
        public static void ClearMonsters() // 전투가 끝나면 리스트를 초기화.
        {
            monsters.Clear();
        }
    }
    public class Battle
    {
        private List<Monster> monsters = new List<Monster>(); // 몬스터 리스트 유지.
        public int defeatCount{ get; private set; } = 0;

        public void BattleStart()
        {
            Console.Clear();
            //적을 발견했다.
            //전투 시작?
            //1. 전투 시작
            //0. 도망가기
            //>> 입력
        }
        //bool combatStart = false; // 전투 시작 조건
        Player player = new Player();
        MainMenu mainMenu = new MainMenu();

        public void PlayerInfo()
        {
            Console.WriteLine("+================================+\n");
            Console.WriteLine("[내 정보]\n");
            Console.Write($"Lv. {player.PlayerLevel} ");
            Console.Write($"이름: {player.Name} ");
            Console.WriteLine($"({player.ClassCode})\n");
            Console.WriteLine($"체력: {player.Health}\n");
            Console.WriteLine("+--------------------------------+\n");
        }
        public void UseActor()
        {
            PlayerInfo();
            Console.WriteLine("1. 공격");
            Console.WriteLine("0. 나가기");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    MonsterFactory.CreateRandomMonster();
                    ShowBattleScene();
                    break;
                case "0":
                    mainMenu.DisplayMainMenu(); // 메인 메뉴.CS에 연결.
                    return;

                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    Console.ReadLine();
                    break;
            }
        }
        public void AttackActor()
        {
            while (true)
            {
                PlayerInfo();
                Console.WriteLine("전투 돌입!!\n");
                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 나가기");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        ShowBattleScene();
                        break;
                    case "0":
                        mainMenu.DisplayMainMenu(); // 메인 메뉴.CS에 연결.
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                        Console.ReadLine();
                        break;
                }
                //List<Monster> randomMonster = MonsterFactory.CreateRandomMonster();
                //foreach (Monster monster in randomMonster)
                //{
                //    monster.ShowInfo();
                //}
            }
        }
        public void BattleMenu()
        {
            List<Monster> monsters = MonsterFactory.CreateRandomMonster();
            while (monsters.Count > 0)
            {
                Console.WriteLine("적 - 공격대상 선택하는 씬\n");

                //적 무작위 출현 로직
                //for (int i = 0; i < monsters.Count; i++)
                //{
                //    Console.WriteLine($"- {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
                //}

                //플레이어 인포 넣을 지 안넣을지 정리중....
                //PlayerInfo();

                string combatInput = Console.ReadLine();
                if (combatInput == "0")
                {
                    Console.WriteLine("도망쳤습니다. 다시 마을로 돌아갑니다.");
                    Console.ReadLine();
                    return;
                }
                if (int.TryParse(combatInput, out int monsterIndex) && monsterIndex >= 1 && monsterIndex <= monsters.Count)
                {
                    Monster target = monsters[monsterIndex - 1];
                    Console.WriteLine();
                    target.Health -= player.Attack; // 플레이어 공격에 몬스터 체력 감소

                    if (target.Health <= 0)
                    {

                        Console.WriteLine($"{target.Name}을 처치했습니다.");
                        monsters.RemoveAt(monsterIndex - 1); // 몬스터 리스트에서 제거 : 임시
                        defeatCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{target.Name}의 체력이 {target.Health} 남았습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                }
                Console.WriteLine("계속 진행하려면 Enter를 누르세요.");
                Console.ReadLine();
            }
            // 모든 적 처치 후 전투 결과 출력
            Console.WriteLine("모든 적 처치! 전투 결과");
            Console.ReadLine();
        }

        public void BattleScene()
        {
            //if (combatStart == false)
            //{
            //    UseActor();
            //}
            //else
            //{
            //    AttackActor();
            //}
        }


        public void ShowBattleScene()
        {

        }
    }
}




