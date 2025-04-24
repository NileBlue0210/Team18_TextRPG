using Sparta_Team18_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Team18_TextRPG
{
    class InventoryUI
    {
        private Player player; //외부에서 받은 player 객체 lord

        public InventoryUI(Player player)
        {
            this.player = player;
        }

        public void ShowInventory()
        {
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("\n====인벤토리====\n");
                Console.WriteLine("\n+====================+");
                var inv = EquipmentManager.GetInventory(player); //player의 인벤토리를 inv에 저장. 리스트형태

                if (inv.Count == 0)
                {
                    Console.WriteLine("\n 인벤토리가 비었습니다.");
                }
                else
                {
                    for (int i = 0; i < inv.Count; i++) //리스트형태라서 count
                    {
                        var item = inv[i];

                        string status = item.IsEquipped ? "[E]" : "[-]";

                        List<string> statPart = new List<string>();
                        if (item.AttackBouns != 0) statPart.Add($"| 공격력 +{item.AttackBouns}");
                        if (item.DefenseBouns != 0) statPart.Add($"| 방어력 +{item.DefenseBouns}");
                        if (item.HealthBouns != 0) statPart.Add($"| 체력 +{item.HealthBouns}");

                        Console.Write($" {i + 1}.{status} {item.itemName} ");

                        if(statPart.Count>0)
                        {
                            for (int j = 0; j < statPart.Count; j++)
                            {
                                string part = statPart[j];
                                string[] split = part.Split('+');;
                                if (split.Length == 2)
                                {
                                string prefix = split[0].Trim();
                                    string suffix = "+" + split[1].Trim();

                                    Console.Write(prefix);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(suffix);
                                    Console.ResetColor();
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\n * 아이템 번호를 눌러 장착/해제 할 수 있습니다.");
                Console.WriteLine("\n 0. 뒤로가기");
                input = Console.ReadLine();

                if (input != "0" && int.TryParse(input, out int idx) && idx >= 1 && idx <= inv.Count)
                {
                    var selected = inv[idx - 1];

                    if (selected.IsEquipped)
                    {
                        EquipmentManager.Unequip(player, selected);
                    }
                    else
                    {
                        EquipmentManager.Equip(player, selected);
                    }
                }
            } while (input != "0");
        }
    }
}

