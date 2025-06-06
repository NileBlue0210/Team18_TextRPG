﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Team18_TextRPG;

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
        EndStageView endStageView = new EndStageView();

        private string name = "";    // 플레이어 이름
        private int playerLevel = 1;    // 플레이어 레벨 to do: 2자릿수로 표시되도록 01, 02 등..
        private int classCode = 1;  // 플레이어 직업 (0: 노비스, 1: 전사, 2: 마법사, 3: 궁수)
        private int attack = 10;   // 공격력   // to do: 공, 방, 체는 나중에 float로 바꾸자
        private int defense = 5;  // 방어력
        private int health = 100;   // 체력
        private int maxHealth = 100; // 최대 체력
        private int gold = 1500; // 골드


        public int Attack => attack;
        public int Defense => defense;
        public int Health => health;


        public PlayerStatus playerState = PlayerStatus.Normal; // 플레이어 상태

        // 플레이어 스테이터스 제어용 프로퍼티
        public string Name
        {
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

        public int TotalAttack
        {
            get
            {

                return this.attack + EquipmentManager.GetAttackBonus();
            }
            set
            {
                attack = value - EquipmentManager.GetAttackBonus();
            }
        }

        public int TotalDefense
        {
            get
            {

                return this.defense + EquipmentManager.GetDefenseBonus();
            }
            set
            {
                defense = value - EquipmentManager.GetDefenseBonus();
            }
        }

        public int TotalHp
        {
            get
            {
                return this.health + EquipmentManager.GetHpBonus();
            }
            set
            {
                health = value - EquipmentManager.GetHpBonus();

                // 플레이어의 체력이 0이 되면 게임 오버 처리
                if (health <= 0)
                {
                    health = 0;
                    //GameManager.Instance.GameOver(); // 배틀부분으로 이동(임시조치). >> 나중에 사용 예정.   
                }
                //else
                //{
                //    if(health > maxHealth) { health = maxHealth; }
                //}
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


        public int PlayerAttack()
        {
            // 공격력의 90% ~ 110% 사이의 랜덤 데미지 생성
            // to do: BattleManager같은 클래스를 만들어서 몬스터 데미지 시퀀스와 통합
            int maxDamage = (int)(this.TotalAttack * 1.1f);
            int minDamage = (int)(this.TotalAttack * 0.9f);

            Random random = new Random();

            int randomDamage = random.Next(minDamage, maxDamage + 1);   // to do: 추후 float로 바꿀 경우 nextdouble을 사용. maxDamage + 1 부분을 float일 경우 어떻게 할 것인지 고려해야 함

            return randomDamage;
        }

        public void ShowPlayerInfo()
        {
            ConvertClassCode classString = new ConvertClassCode();

            Console.WriteLine("\n");
            Console.WriteLine("\n+================================+\n");
            Console.WriteLine("[내 정보]\n");
            Console.Write($"Lv. {this.PlayerLevel} ");
            Console.Write($"이름: {this.Name} ");
            Console.WriteLine($"({classString.ConvertClassCodeToString(this.ClassCode)})\n");
            Console.WriteLine($"체력: {this.TotalHp}\n");
            Console.WriteLine("+--------------------------------+\n");
        }


    }
}
