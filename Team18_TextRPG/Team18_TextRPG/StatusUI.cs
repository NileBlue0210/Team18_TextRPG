using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_Team18_TextRPG;
using Team18_TextRPG;

namespace Sparta_Team18_TextRPG
{
    class StatusUI
    {
        ConvertClassCode convertClassCode = new ConvertClassCode();

        private Player player;
        public StatusUI(Player player)
        {
            this.player = player;
        }

        public void ShowStat()
        {
            string className = convertClassCode.ConvertClassCodeToString(player.ClassCode);

            {
                Console.Clear();

                Console.WriteLine("\n====[상태보기]====");
                Console.WriteLine("\n 캐릭터의 정보가 표시됩니다. ");
                Console.WriteLine($"\n+====================+");
                Console.WriteLine($"\n Lv.{player.PlayerLevel} | {player.Name} | {className} \n");

                int baseAtk = player.Attack;
                int bonusAtk = EquipmentManager.GetEquipped(player).Sum(it => it.AttackBouns);
                PrintStatLine("\n 공격력", baseAtk, bonusAtk);

                int baseDef = player.Defense;
                int bonusDef = EquipmentManager.GetEquipped(player).Sum(it => it.DefenseBouns);
                PrintStatLine("\n 방어력", baseDef, bonusDef);

                int baseHp = player.Health;
                int bonusHp = EquipmentManager.GetEquipped(player).Sum(it => it.HealthBouns);
                PrintStatLine("\n 체 력", baseHp, bonusHp);
                //EquipmentManager.GetEquipped(player): 플레이어가 장착중인 장비리스트 반환
                // .Sum : Linq 기능 중 리스트에 있는 값을 조건에 맞게 합치는 문법
                // it=> it.AttackBouns : 람다식 it, 지금 받고있는 리스트안에서 AttackBonus만 꺼내라는 뜻

                Console.WriteLine($"\n 소지금: {player.Gold} G");

                Console.WriteLine("\n0. 나가기");
                Console.ReadLine();

            }
        }
        private void PrintStatLine(string label, int baseValue, int bonusValue)
        {
            int total = baseValue + bonusValue;

            string prefix = $"{label}: {total} [{baseValue} + ";
            string suffix = "]";

            Console.Write(prefix);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(bonusValue.ToString());
            Console.ResetColor();
            Console.WriteLine(suffix);
        }
    }
}
