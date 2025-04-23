using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// to do: 추후 별도 파일에 enum모두 정리할 것
public enum PlayerStatus
{
    Normal,
    Die,
    // poison, bleed, burn, freeze 등의 상태이상 추가 가능
}

namespace Sparta_Team18_TextRPG
{
    public class Player
    {
        private string name = "";    // 플레이어 이름
        private int playerLevel = 1;    // 플레이어 레벨 to do: 2자릿수로 표시되도록 01, 02 등..
        private int classCode = 1;  // 플레이어 직업 (0: 노비스, 1: 전사, 2: 마법사, 3: 궁수)
        private int attack = 10;   // 공격력   // to do: 공, 방, 체는 나중에 float로 바꾸자
        private int defense = 5;  // 방어력
        private int health = 100;   // 체력
        private int gold = 1500; // 골드

        public PlayerStatus playerState = PlayerStatus.Normal; // 플레이어 상태

        // 플레이어 스테이터스 제어용 프로퍼티
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int PlayerLevel
        {
            get
            {
                return playerLevel;
            }
            set
            {
                playerLevel = value;
            }
        }
        public int ClassCode
        {
            get
            {
                return classCode;
            }
            set
            {
                classCode = value;
            }
        }
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        }
        public int Defense
        {
            get
            {
                return defense;
            }
            set
            {
                defense = value;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;

                // 플레이어의 체력이 0이 되면 게임 오버 처리
                if (health <= 0)
                {
                    GameManager.Instance.GameOver();
                }
            }
        }
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }

        public void PlayerAttack(Monster targetMonster)
        {
            // 공격력의 90% ~ 110% 사이의 랜덤 데미지 생성
            // to do: BattleManager같은 클래스를 만들어서 몬스터 데미지 시퀀스와 통합
            int maxDamage = (int)(this.Attack * 1.1f);
            int minDamage = (int)(this.Attack * 0.9f);

            Random random = new Random();

            int randomDamage = random.Next(minDamage, maxDamage + 1);   // to do: 추후 float로 바꿀 경우 nextdouble을 사용. maxDamage + 1 부분을 float일 경우 어떻게 할 것인지 고려해야 함

            targetMonster.Health -= randomDamage;

            Console.WriteLine($"{targetMonster.Name}(을)를 공격! {randomDamage}의 데미지를 입혔습니다.");

            // 공격으로 인해 적이 사망했을 경우, 사망 처리. 아닐 경우 데미지 계산
            if (targetMonster.Health <= 0)
            {
                targetMonster.Health = 0; // 에러 대비 체력이 음수라도 0으로 고정
                targetMonster.MonsterDie(targetMonster);

                Console.WriteLine($"{targetMonster.Name}(을)를 처치했습니다.");
            }
        }

        public void PlayerHit()
        {

        }

        public void PlayerDie()
        {
            playerState = PlayerStatus.Die;

            Console.WriteLine("플레이어가 사망했습니다.");
            // to do: 플레이어 사망 처리 추가
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n+================================+\n");
            Console.WriteLine("[내 정보]\n");
            Console.Write($"Lv. {this.PlayerLevel} ");
            Console.Write($"이름: {this.Name} ");
            Console.WriteLine($"({this.ClassCode})\n");
            Console.WriteLine($"체력: {this.Health}\n");
            Console.WriteLine("+--------------------------------+\n");
        }
    }
}
