using System;

namespace Sparta_Team18_TextRPG
{
    public class Phase // 공격 턴 클래스
    {

        //Player 공격 차례
        //Enemy 공격 차례
        public void PlayerTurn()
        {
            Console.WriteLine("Player 공격");
            Console.WriteLine("PlayerTurn 실행 성공");
            Console.WriteLine("계속하기(Enter)");
            Console.ReadLine();
            EnemyTurn();
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

