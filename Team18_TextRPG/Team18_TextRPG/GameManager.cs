using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Sparta_Team18_TextRPG
{
    public class GameManager
    {
        private static GameManager instance;

        // 싱글턴 패턴 구현
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();

                }

                return instance;
            }
        }

        public Player player { get; private set; }

        private GameManager()
        {
            player = new Player();
        }

        // 질문 텍스트 함수화
        public void Ask()
        {
            Console.WriteLine("\n");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
        }

        public void GameOver()
        {
            EndStageView endStageView = new EndStageView();

            // endStageView.EndStage(false);
        }
    }
}
