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

        private GameManager()
        {

        }

        public void GameOver()
        {
            Player player = new Player();

            Console.WriteLine($"게임 오버. {player.Name}이 쓰러졌습니다.");
        }
    }
}
