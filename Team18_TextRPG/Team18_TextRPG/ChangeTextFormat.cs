using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team18_TextRPG
{
    // 텍스트 형식을 변경하는 함수
    public class ChangeTextFormat
    {
        // 텍스트 색을 변경해서 출력
        public static void ChangeTextColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
