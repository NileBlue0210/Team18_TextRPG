using System;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Team18_TextRPG;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_Team18_TextRPG
{
    public class Battle
    {
        StringBuilder sb = new StringBuilder(); //문자빌더
        MainMenu mainmenu = new MainMenu();
        BattleManager battleManager = new BattleManager();
        EndStageView endStageView = new EndStageView();

        private List<Monster> monsters = new List<Monster>();
        public void BattleStart()
        {
            ChangeTextFormat changeTextFormat = new ChangeTextFormat();

            Console.Clear();
            monsters = MonsterFactory.GetOrCreateMonsters();
            Console.WriteLine($"\n몬스터가 보인다.\n");
            Console.WriteLine($"\n[ 적 무리: {monsters.Count} ]\n\n");
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"- Lv.{monsters[i].Level} {monsters[i].Name} | 체력: {monsters[i].HealthStatus()} | 공격력: {monsters[i].Attack}");
            }
            GameManager.Instance.player.ShowPlayerInfo();

            Console.WriteLine("전투를 시작합니다.");
            Console.Write("\n");

            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 도망가기");
            GameManager.Instance.Ask();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    MonsterFactory.GetOrCreateMonsters();
                    // 기존 몬스터 유지
                    Combat();
                    break;
                case "2":
                    Console.Clear();
                    monsters.Clear();
                    Console.WriteLine("도망쳤습니다. 다시 마을로 돌아갑니다.");
                    // mainmenu.DisplayMainMenu();
                    Program.ChangeView(EViewName.Main);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    BattleStart();
                    break;
            }
        }

        private void Combat()
        {
            Console.Clear();

            PlayerTurn(GameManager.Instance.player, monsters);
        }

        private void PlayerTurn(Player player, List<Monster> monsters)
        {
            string userInput = "";
            
            Console.WriteLine($"\n총 {monsters.Count}마리의 몬스터가 등장!\n");

            while (monsters.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n[ 적 무리 ]\n\n");
                
                for (int i = 0; i < monsters.Count; i++)
                {
                    // 이미 죽은 몬스터일 경우, 텍스트 색상을 어둡게 변경
                    if (monsters[i].Status.Contains(MonsterStatus.Dead))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.WriteLine($"{i + 1}) Lv.{monsters[i].Level} {monsters[i].Name} | 체력: {monsters[i].HealthStatus()} | 공격력: {monsters[i].Attack}");
                    Console.ResetColor();
                }

                GameManager.Instance.player.ShowPlayerInfo();

                Console.WriteLine("공격할 몬스터를 선택하세요!\n");
                Console.WriteLine("0.페이즈 넘기기");
                Console.Write(">> ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("기회를 놓쳤다. 몬스터들이 덤벼든다.");
                        MonsterAttack();
                        break;
                    default:
                        if (int.TryParse(userInput, out int monsterIndex) && monsterIndex >= 1 && monsterIndex <= monsters.Count)
                        {
                            Monster target = monsters[monsterIndex - 1];

                            int damage = battleManager.GetDamageValue();
                            int totalDamage = battleManager.GetHitDamageValue(target, damage);

                            target.MonsterHit(totalDamage); // 적: 피격 시 메서드 호출

                            MonsterAttack(); // 몬스터 반격

                            if (GameManager.Instance.player.Health <= 0) // 플레이어 죽음
                            {
                                GameManager.Instance.GameOver();
                                Console.ReadLine();
                                return;
                            }
                            else if (monsters.All(m => !m.Status.Contains(MonsterStatus.IsAlive))) //몬스터 노말 상태가 없으면 전투 종료
                            {
                                BattleEnd();
                                return;
                            }
                        }
                        break;
                }
            }
            //BattleEnd(); // 전투 종료되면 마을로 돌아가기 실행.
            Program.ChangeView(EViewName.Main);
        }

        private void MonsterAttack()
        {
            Console.Clear();
            Console.WriteLine($"\n몬스터들의 반격!\n");
            foreach (Monster monster in monsters)
            {
                if (monster.Health <= 0) continue; // 몬스터 체력: 0 되면 정지
                if (GameManager.Instance.player.Health <= 0) break; //플레이어 '체력: 0' 되면 정지

                int damage = battleManager.GetDamageValue(monster); // 몬스터 공격력 계산
                int totalDamage = battleManager.GetHitDamageValue(damage); // 플레이어가 받을 데미지 계산
                GameManager.Instance.player.TotalHp -= totalDamage;

                //Thread.Sleep(1000);
                Console.Write($"\n적: {monster.Name} 공격! ");
                ChangeTextFormat.ChangeTextColor(totalDamage.ToString(), ConsoleColor.Red);
                Console.Write(" 데미지!!");
                Console.WriteLine("\n");
                Thread.Sleep(1000);
                Console.Write($"이름: {GameManager.Instance.player.Name} | 남은 체력: ");
                ChangeTextFormat.ChangeTextColor(GameManager.Instance.player.TotalHp.ToString(), ConsoleColor.Yellow);
                Console.WriteLine("");
                Thread.Sleep(1000);
                //Console.ReadLine();
            }
            //if (player.Health <= 0)
            //{
            //    monsters.Clear();
            //    GameManager.Instance.GameOver();  
            //}
            return;
        }

        public void BattleEnd()
        {
            Console.WriteLine("모든 적을 처치했습니다!");
            Thread.Sleep(1000);
            //int defeatedMonsterCount = monsters.Count(m => m.Status.Contains(MonsterStatus.Dead));
            endStageView.EndStage(true, monsters);

            //Console.WriteLine("계속 하려면 Enter를 누르세요.");
            //Console.Write(">> ");
            //monsters.Clear(); // 리스트 초기화 >> EndStageView로 이동.

            //Console.ReadLine();
            return;
        }
    }
}




