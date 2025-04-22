using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_Team18_TextRPG
{
    public class InputValidator
    {
        // 플레이어가 몬스터 공격 시의 선택지를 골랐을 때의 유효성 검사
        // memo: 아래 메소드를 오버로딩해서 인수 타입에 따른 처리를 구분 가능
        public bool CheckSelectUserInput(List<Monster> monsterList, int userInput)
        {
            bool result = true;

            if (monsterList.Count < userInput || userInput < 0)
            {
                result = false;

                Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
            }

            return result;
        }

        // 플레이어 입력이 숫자인지 검사하고, 숫자일 경우 int로 변환
        public bool CheckAndConvertUserInput(string userInput)
        {
            bool result = false;

            // 숫자 입력 여부 검사
            if (int.TryParse(userInput, out int number))
            {
                result = true;
            }

            // to do: else일 경우 여기서 처리할 것
            //  에러 메세지 출력용 클래스를 만들어서 에러메세지를 출력하도록 하는 게 좋을 것 같다

            return result;
        }
    }
}
