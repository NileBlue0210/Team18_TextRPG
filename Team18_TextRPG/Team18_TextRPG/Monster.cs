using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public enum MonsterStatus
{
    IsAlive, // 살아있는 상태.
    Normal,
    Dead,
    // poison, bleed, burn, freeze 등의 상태이상 추가 가능
}

namespace Sparta_Team18_TextRPG
{
    public class Monster
    {
        // 몬스터 스테이터스 제어용 프로퍼티
        public int Level { get; set; }
        public string Name { get; set; }
        public float Health { get; set; }
        public float Attack { get; set; }
        public HashSet<MonsterStatus> Status { get; set; } // 몬스터 여러 상태 저장
        Player player = new Player();

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
            Health -= player.PlayerAttack(); // 전투 테스트용(여기서 데미지 계산)
            if (Health > 0 && Status.Contains(MonsterStatus.IsAlive))
            {
                Console.WriteLine($"{player.PlayerAttack()} 데미지!!");
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
