using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public enum MonsterStatus
{
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
        public MonsterStatus Status { get; set; }

        public Monster(int level, string name, int health,  int attack, MonsterStatus status  )
        {
            Level = level;
            Name = name;
            Health = health;
            Attack = attack;
            Status = status;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"- 적: {Name} | 체력: {HealthStatus()} | 공격력: {Attack}");
        }

        public void MonsterAttack()
        {

        }
        public void MonsterHit(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Status = MonsterStatus.Dead;
            }
        }
        public string HealthStatus()
        {
            return Status == MonsterStatus.Dead ? "DEAD" : Health.ToString();
        }
        // 체력 표시 부분을 Dead로 표시
        // 몬스터 텍스트 색 변경: 회색
        public void MonsterDie()
        {
            Status = MonsterStatus.Dead;
        }
    }
}
