using Sparta_Team18_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Team18_TextRPG
{
    public class ShopManager
    {
        private List<Item> shopItems = new List<Item>();

        public ShopManager()
        {
            shopItems.Add(new Item(0, "주먹도끼", "마구잡이로 깎여 주먹에 쥐기 좋은 돌덩이", 2, 0, 0, 20));
            shopItems.Add(new Item(1, "가죽 옷", "무두질이 잘 되어있지않아서 질긴 옷", 0, 3, 0, 50));
            shopItems.Add(new Item(2, "활력의 목걸이", "왜인지 기분이 좋아지는 목걸이", 0, 0, 10, 100));

        }

        public void ShowShop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n====상점====");
                Console.WriteLine("\n 아이템 목록");
                Console.WriteLine("\n+====================+");

                List<Item> myInventory = EquipmentManager.GetInventory();

                for (int i = 0; i < shopItems.Count; i++)
                {

                    PrintShopItem(shopItems[i], myInventory,i);
                 
                }
                Console.WriteLine(" \n 구매할 아이템 번호를 선택하세요.");
                Console.WriteLine("\n 0.나가기");
                string input = Console.ReadLine();

                if (input == "0")
                    break;

                if (int.TryParse(input, out int index) && index > 0 && index <= shopItems.Count)
                {
                    Item selectedItem = shopItems[index - 1];

                    bool alreadyOwned = myInventory.Any(invItem => invItem.itemID == selectedItem.itemID);
                    if (alreadyOwned)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }

                    else if (GameManager.Instance.player.Gold >= selectedItem.Price)
                    {
                        GameManager.Instance.player.Gold -= selectedItem.Price;

                        EquipmentManager.GetInventory().Add(selectedItem);
                        Console.WriteLine($"{selectedItem.itemName}을(를) 구매했습니다.");
                    }
                    else
                    {
                        Console.WriteLine("골드가 충분하지 않습니다.");
                    }

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                Console.WriteLine("\n 계속하려면 아무 키나 누르세요.");
                Console.ReadLine();
            }

        }
        private void PrintShopItem(Item item, List<Item> inventory, int index)
        {
            bool isOwned = inventory.Any(invItem => invItem.itemID == item.itemID);
            string itemStatus = isOwned ? "[구매됨]" : "[구매가능]";
            Console.ForegroundColor = isOwned ? ConsoleColor.DarkGray : ConsoleColor.White;

            Console.WriteLine($"{index + 1}. {item.itemName} | {item.Description}");
            Console.WriteLine($"     ㄴ가격: {item.Price}G {itemStatus}\n");
            Console.ResetColor();
        }
    }
}
