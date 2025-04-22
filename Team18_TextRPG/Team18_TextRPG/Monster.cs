using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// to do: 추후 별도 파일에 enum모두 정리할 것
public enum MonsterStatus
{
    Normal,
    Die,
    // poison, bleed, burn, freeze 등의 상태이상 추가 가능
}

namespace Sparta_Team18_TextRPG
{
    public class Monster
    {
        private string name = "";    // 몬스터 이름
        private int monsterLevel = 0;    // 몬스터 레벨
        private float attack = 0;   // 공격력
        private float defense = 0;  // 방어력
        private float health = 0;   // 체력

        public MonsterStatus monsterState = MonsterStatus.Normal; // 몬스터 상태

        // 몬스터 스테이터스 제어용 프로퍼티
        public string Name { get; set; }
        public int MonsterLevel { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }
        public float Health { get; set; }

        public void MonsterAttack()
        {

        }
        public void MonsterHit()
        {

        }

        // 체력 표시 부분을 Dead로 표시
        // 몬스터 텍스트 색 변경: 회색
        public void MonsterDie()
        {
            monsterState = MonsterStatus.Die;
        }
    }
}
