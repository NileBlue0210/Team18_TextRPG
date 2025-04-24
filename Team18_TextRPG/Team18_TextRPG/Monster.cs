using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Team18_TextRPG;

public enum MonsterStatus
{
    IsAlive, // 살아있는 상태.
    Normal,
    Dead,
    // poison, bleed, burn, freeze 등의 상태이상 추가 가능
}

namespace Sparta_Team18_TextRPG
{
    public class MonsterFactory
    {
        private static Random random = new Random();
        private static List<Monster> monsters = new List<Monster>();

        private static Dictionary<string, (int level, int minHealth, int maxHealth, int minAttack, int maxAttack)> monsterStats =
        new Dictionary<string, (int, int, int, int, int)>
        {
            { "  슬라임  ", (1, 10, 20, 3, 8) },
            { "  고블린  ", (2, 15, 25, 10, 20) },
            { "   좀비   ", (3, 16, 26, 3, 25) },
            { " 스켈레톤 ", (5, 30, 45, 10, 12) },
            { "   늑대   ", (7, 35, 60, 12, 15) },
            { "   거미   ", (7, 20, 27, 3, 13) },
            { "   트롤   ", (10, 80, 120, 20, 35) },
            { "   오크   ", (15, 40, 50, 15, 25) },
            { "  사냥꾼  ", (12, 35, 50, 22, 27) },
            { "  암살자  ", (20, 23, 34, 12, 37) },
            { " 흑마법사 ", (24, 17, 29, 33, 40) },
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

                    int level = stats.level + random.Next(1, 4);
                    int health = random.Next(stats.minHealth, stats.maxHealth + 1);
                    int attack = random.Next(stats.minAttack, stats.maxAttack + 1);

                    monsters.Add(new Monster(level, name, health, attack, MonsterStatus.Normal));
                }
            }
            return monsters;
        }

        public static void ClearMonsters()
        {
            monsters.Clear();
        }
    }

    public class Monster
    {
        // 몬스터 스테이터스 제어용 프로퍼티
        public int Level { get; set; }
        public string Name { get; set; }
        public float Health { get; set; }
        public float Attack { get; set; }
        public HashSet<MonsterStatus> Status { get; set; } // 몬스터 여러 상태 저장
        Player player = new Player();
        BattleManager battleManager = new BattleManager();

        public Monster(int level, string name, int health,  int attack, MonsterStatus status  )
        {
            Level = level;
            Name = name;
            Health = health;
            Attack = attack;
            Status = new HashSet<MonsterStatus> { MonsterStatus.IsAlive }; // 기본적으로 노말 상태 저장.
        }

        public void ShowInfo()
        {
            Console.WriteLine($"- 적: {Name} | 체력: {HealthStatus()} | 공격력: {Attack}");
        }

        public void MonsterAttack()
        {

        }
        public void MonsterHit(int damage) //몬스터가 받는 데미지 계산은 여기서.
        {
            Console.Clear();
            Health -= damage; // 전투 테스트용(여기서 데미지 계산)
            if (Health > 0 && Status.Contains(MonsterStatus.IsAlive))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{damage}");
                Console.ResetColor();
                Console.WriteLine(" 데미지!!");
                Console.ReadLine();
            }
            while (true)
            {
                if (Health <= 0 && Status.Contains(MonsterStatus.IsAlive))
                {
                    Health = 0;
                    Status.Clear();
                    Status.Add(MonsterStatus.Dead);
                    Console.WriteLine($"{Name}을(를) 처치했다!");
                    Console.ReadLine();
                }
                else if (Status.Contains(MonsterStatus.Dead))
                {
                    Console.WriteLine($"{Name}은(는) 이미 쓰러졌다! 몬스터들이 덤벼든다!");
                    Console.ReadLine();
                }
                return;
            }
        }
        public void MonsterAddStatus(MonsterStatus status)
        {
            if (status == MonsterStatus.Dead)
            {
                Status.Clear();
                Status.Add(MonsterStatus.Dead);
            }
            else
            {
                Status.Add(status); // 중첩 상태 이상 적용
            }
        }
        public string HealthStatus()
        {
            return Status.Contains(MonsterStatus.Dead) ? "DEAD" : Health.ToString();
        }
        // 체력 표시 부분을 Dead로 표시
        // 몬스터 텍스트 색 변경: 회색

        public void MonsterDie()
        {
            Status.Contains(MonsterStatus.Dead);
        }
    }
}
