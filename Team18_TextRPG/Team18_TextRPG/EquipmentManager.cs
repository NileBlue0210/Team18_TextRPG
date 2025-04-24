using Sparta_Team18_TextRPG;

namespace Team18_TextRPG
{
    public static class EquipmentManager
    {       
        private static Dictionary<Player, (List<Item> Inventory, List<Item> Equipped)> _map
            = new();
              //딕셔너리 <key: Player 누구의 정보인지 구분, (Value: Inventory, Equipped) 라는 튜플 

        private static void EquipPlayer(Player player)
        {
            if (!_map.ContainsKey(player))
                _map[player] = (new List<Item>(), new List<Item>());
        }   //메서드 초기화. _map에 player 키가 없으면 new List 두개를 묶어서 _map[player]에 저장

        public static List<Item> GetInventory(Player player)
        {
            EquipPlayer(player);
            return _map[player].Inventory;
        }

        public static List<Item> GetEquipped(Player player)
        {
            EquipPlayer(player);
            return _map[player].Equipped;
        }   //리스트에서 꺼내기

        public static void Equip(Player player, Item item)
        {
            EquipPlayer(player);
            var (inv, eq) = _map[player];// 튜플 언패킹
            if (!inv.Contains(item))    // 인벤토리에 없으면
            {
                return;
            }
            if (eq.Contains(item))      // 장착이 이미 되었으면
            {
                return;
            }
            eq.Add(item);               // 장착한 리스트에 추가
            item.IsEquipped = true;     // 아이템 장착으로 상태변경
        }

        public static void Unequip(Player player, Item item)
        {
            EquipPlayer(player);
            var (inv, eq) = _map[player];
            if (!eq.Contains(item))
            {
                return;
            }
            eq.Remove(item);
            item.IsEquipped = false;    // 장착 해제
        }
    }
}
