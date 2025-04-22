using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Team18_TextRPG
{
    // 플레이어 클래스 코드를 문자로 반환
    // memo: classCode를 일일히 문자열로 작성했을 시, 오타로 인해 발생할 오류를 방지하기 위함
    public class ConvertClassCode
    {
        public string ConvertClassCodeToString(int classCode)
        {
            string result = "";

            switch (classCode)
            {
                case 0:
                    result = "노비스";
                    break;
                case 1:
                    result = "전사";
                    break;
                case 2:
                    result = "마법사";
                    break;
                case 3:
                    result = "궁수";
                    break;
                default:
                    Console.Error.WriteLine("잘못된 직업 코드입니다.");
                    break;
            }

            return result;
        }
    }
}
