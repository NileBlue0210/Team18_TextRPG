using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MonsterStatus
{
    Normal,
    Die,
    // poison, bleed, burn, freeze 등의 상태이상 추가 가능
}

namespace Sparta_Team18_TextRPG
{
    public class Monster
    {
        // 몬스터 스테이터스 제어용 프로퍼티
        public string Name { get; set; }
        public float Health { get; set; }
        public float Attack { get; set; }

        public Monster(string name, int health,  int attack  )
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"적: {Name} | 체력: {Health} | 공격력: {Attack}");
        }

        public void MonsterAttack()
        {

        }
        public void MonsterHit()
        {

        }

        // 체력 표시 부분을 Dead로 표시
        // 몬스터 텍스트 색 변경: 회색
        //public void MonsterDie()
        //{
        //    monsterState = MonsterStatus.Die;
        //}
    }
}
