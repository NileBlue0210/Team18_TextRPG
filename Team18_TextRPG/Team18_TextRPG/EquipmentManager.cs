using Sparta_Team18_TextRPG;

namespace Team18_TextRPG
{
    public static class EquipmentManager
    {       
        private static Dictionary<Player, (List<Item> Inventory, List<Item> Equipped)> _map
            = new();
              //딕셔너리 <key: Player 누구의 정보인지 구분, (Value: Inventory, Equipped) 라는 튜플 
              //플레이어별로 인벤토리와 장착 장비 리스트를 저장함.
        private static void EquipPlayer(Player player)
        {
            if (!_map.ContainsKey(player))
                _map[player] = (new List<Item>(), new List<Item>());
        }   //메서드 초기화. _map에 player 키가 없으면 new List 두개를 묶어서 _map[player]에 저장

        public static List<Item> GetInventory(Player player)
            //플레이어 인벤토리 리스트 반환
        {
            EquipPlayer(player);
            return _map[player].Inventory;
        }

        public static List<Item> GetEquipped(Player player)
        {   //플레이어 장착 리스트를 반환
            EquipPlayer(player);
            return _map[player].Equipped;
        }   

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
        }   // 인벤토리에 있는 아이템만 장착 가능

        public static void Unequip(Player player, Item item)
        {
            EquipPlayer(player);
            var (inv, eq) = _map[player];
            if (!eq.Contains(item))
            {
                return;
            }
            eq.Remove(item);
            item.IsEquipped = false;
        }   // 장착 해제
        
        public static int GetAttackBonus(Player player)
        {
            return GetEquipped(player).Sum(item => item.AttackBouns);
        }   // 장비된 무기 공격력을 추가하는 로직

        public static int GetDefenseBonus(Player player)
        {
            return GetEquipped(player).Sum(item => item.DefenseBouns);
        }   //  장비된 방어력을 추가하는 로직
        public static int GetHpBonus(Player player)
        {
            return GetEquipped(player).Sum(item=> item.HealthBouns);
        }   // 장비된 체력을 추가하는 로직

        public static void ResetItem()
        {
            _map.Clear(); 
        } //인벤토리 초기화
    }
    
}
