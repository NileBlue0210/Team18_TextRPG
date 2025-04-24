using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta_Team18_TextRPG;

namespace Team18_TextRPG
{
    public class Item
    {
        public int itemID { get; }
        public string itemName { get; }
        public string Description { get; }
        public int AttackBouns { get; }
        public int DefenseBouns { get; }
        public int HealthBouns { get; }
        public int Price { get; }
        public bool IsOwned { get; set; } // 소유여부
        public bool IsEquipped { get; set; } // 장착여부

        public Item(int itemID, string itemName, string description, int attackBouns, int defenseBouns, int healthBouns, int price = 0)
        {
          this.itemID = itemID;
            this.itemName = itemName;
            Description = description;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            HealthBouns = healthBouns;
            Price = price;
            IsOwned = false;
            IsEquipped = false;  
        }
        
    }
}
