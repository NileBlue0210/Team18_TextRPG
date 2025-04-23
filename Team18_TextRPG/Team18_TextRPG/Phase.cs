using System;

namespace Sparta_Team18_TextRPG
{
    /*
 * essue: 공격 시퀀스를 구현
 * 
 * to do:
 * 1. 전투 시작 후, 선공권은 플레이어에게 있다
 *  나중에 스테이터스에 speed와 같은 게 생긴다면 이 로직이 바뀔 수도 있으니 생각하고 구현하자
 * 2. 플레이어 공격이 끝나면 몬스터의 턴이 온다
 * 3. 몬스터 턴은 해당 턴에 생존한 몬스터 수만큼 배정된다
 *  MonstStatus.Die로 판별
 * 4. 이 클래스에서는 아군(주인공 이외의 npc가 등장할 것을 상정)과 적군의 List를 받아 아군과 적군 개개별로 행동할 수 있도록 하는 제어
 * 5. 아군 / 적군 리스트를 반복, .Status가 Normal일 경우 Player/Monster Attack을 실행
 * =============================================================question: Phase클래스를 사용해서 턴을 넘기는 이런 방법밖에 없나?
 * 
 * 
 * 1. 메인메뉴에서 2번을 눌러 전투 발생
 * 2. 전투 시작(조우)
 * ---------------------------Phase
 * 3. 플레이어 적 선택
 * 4. 공격
 * 5. 몬스터 공격 (각개)
 */
    public class Phase // 공격 턴 클래스
    {
        // to do: 플레이어에게 동료가 생길 경우, List로 매개변수를 받아서 플레이어도 아군 수만큼 턴을 잡을 수 있도록 하자
        public void PlayerTurn(Player player, List<Monster> monsterList)
        {
            string userInput = "";
            Monster targetMonster;  // 공격 대상 몬스터

            InputValidator inputValidator = new InputValidator();   // 플레이어 입력 유효성 검사 클래스

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");

                userInput = Console.ReadLine();

                // 사용자 입력이 숫자가 아닐 경우, 음수를 반환
                int chooseNumber = inputValidator.CheckAndConvertUserInput(userInput);

                // 사용자 입력이 숫자인지를 판별해, 숫자가 아닐 경우 다시 질문한다
                if (chooseNumber >= 0)
                {
                    targetMonster = monsterList[chooseNumber];

                    // 플레이어의 입력이 유효한 몬스터 번호가 아니거나, 음수일 경우 다시 질문한다
                    if (!inputValidator.CheckSelectUserInput(monsterList, chooseNumber))
                    {
                        break;
                    }

                    // 선택한 몬스터가 이미 죽어있을 경우, 다시 질문한다
                    if (targetMonster.Status.Contains(MonsterStatus.Dead))
                    {
                        Console.WriteLine($"{targetMonster.Name}(은)는 이미 쓰러진 상태입니다. 다른 공격대상을 선택해주세요).");

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            // 공격 시퀀스 진행
            player.PlayerAttack(targetMonster);
        }

        public void EnemyTurn()
        {
            Console.WriteLine("적 1 공격");
            Console.WriteLine("EnemyTurn 실행 성공");
            Console.WriteLine("계속하기(Enter)");
            Console.ReadLine();
            return;
        }
    }
}

