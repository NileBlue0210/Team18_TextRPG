using System;
using System.Numerics;

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
 */
    public class Phase // 공격 턴 클래스
    {
        Battle battle;

        // to do: 플레이어에게 동료가 생길 경우, List로 매개변수를 받아서 플레이어도 아군 수만큼 턴을 잡을 수 있도록 하자
        public void PlayerTurn(Player player, List<Monster> monsters)
        {
            string userInput = "";
            InputValidator inputValidator = new InputValidator();   // 플레이어 입력 유효성 검사 클래스

            Console.WriteLine($"\n총 {monsters.Count}마리의 몬스터가 등장!\n");

            while (monsters.Count > 0 && player.Health > 0) //플레이어 체력 0보다 크면 행동
            {
                Console.Clear();
                Console.WriteLine("\n[적 무리]\n");

                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name} | 체력: {monsters[i].Health} | 공격력: {monsters[i].Attack}");
                }
                if (monsters.Count == 0)
                {
                    battle.BattleEnd();
                }

                player.ShowPlayerInfo();

                Console.WriteLine("공격할 몬스터를 선택하세요!");
                Console.WriteLine("0.도망가기");
                Console.Write(">> ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Write("도망쳤습니다. 다시 마을로 돌아갑니다.");
                        Console.ReadLine();
                        return;

                    default:
                        if (int.TryParse(userInput, out int monsterIndex) && monsterIndex >= 1 && monsterIndex <= monsters.Count)
                        {
                            Monster target = monsters[monsterIndex - 1];

                            int battleDamage = player.PlayerAttack(target);

                            target.Health -= battleDamage;

                            Console.WriteLine($"{target.Name}에게 공격!");

                            // 몬스터 처치 시 사망 처리, 아닐 경우 데미지 계산
                            if (target.Health <= 0)
                            {
                                target.Health = 0; // 체력이 음수라도 0으로 고정
                                target.MonsterDie(target);

                                Console.WriteLine($"{target.Name}(을)를 처치했습니다.");

                                monsters.RemoveAt(monsterIndex - 1);
                            }
                            else
                            {
                                battle.MonsterAttack();
                            }
                        }
                        break;
                }
                Console.WriteLine("\n계속 진행하려면 Enter를 누르세요.");
                Console.ReadLine();
            }
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

