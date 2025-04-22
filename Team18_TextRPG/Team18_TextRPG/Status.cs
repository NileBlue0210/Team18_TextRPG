using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_Team18_TextRPG; //Player클래스 네임스페이스

namespace Sparta_Team18_TextRPG
{
    class Status
    {
        public void ShowStat()
        {
            Player player = new Player();
            ConvertClassCode convertClassCode = new ConvertClassCode();

            string className = convertClassCode.ConvertClassCodeToString(player.ClassCode);

            Console.WriteLine(" [상태보기] ");
            Console.WriteLine("\n 캐릭터의 정보가 표시됩니다. ");
            Console.WriteLine($"\n +=========================+");
            Console.WriteLine($"\n Lv. {player.PlayerLevel}");
            Console.WriteLine($" Chad ( {className} )");
            Console.WriteLine($" 공격력 : {player.Attack}");
            Console.WriteLine($" 방어력 : {player.Defense}");
            Console.WriteLine($" 체 력 : {player.Health}");
            Console.WriteLine($" Gold : {player.Gold}");

            Console.WriteLine("\n1");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.");





        }
    }
}
