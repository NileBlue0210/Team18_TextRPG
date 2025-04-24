using Sparta_Team18_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EViewName
{
    Main,
    Status,
    Inventory,
    Shop,
    Battle,
    Result
}

namespace Team18_TextRPG
{
    internal class Program
    {
        public void Main()
        {
            ChangeView(EViewName.Main);
        }

        public void ChangeView(EViewName viewName)
        {
            switch (viewName)
            {
                case EViewName.Main:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.DisplayMainMenu();
                    break;
                case EViewName.Status:
                    StatusUI status = new StatusUI();
                    status.ShowStat();
                    break;
                case EViewName.Inventory:
                    InventoryUI inventory = new InventoryUI();
                    inventory.ShowInventory();
                    break;
                case EViewName.Shop:
                    ShopManager shop = new ShopManager();
                    shop.OpenShop();
                    break;
                case EViewName.Battle:
                    Battle battle = new Battle();
                    battle.BattleStart();
                    break;
                case EViewName.Result:
                    EndStageView result = new EndStageView();
                    break;
                default:
                    break;
            }
        }
    }
}
