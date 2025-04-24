using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Sparta_Team18_TextRPG;

namespace Team18_TextRPG
{
    public class BattleManager
    {
        public int GetDamageValue()
        {
            // 공격력의 90% ~ 110% 사이의 랜덤 데미지 생성
            // to do: BattleManager같은 클래스를 만들어서 몬스터 데미지 시퀀스와 통합
            int maxDamage = (int)(GameManager.Instance.player.TotalAttack * 1.1f);
            int minDamage = (int)(GameManager.Instance.player.TotalAttack * 0.9f);

            Random random = new Random();

            int randomDamage = random.Next(minDamage, maxDamage + 1);   // to do: 추후 float로 바꿀 경우 nextdouble을 사용. maxDamage + 1 부분을 float일 경우 어떻게 할 것인지 고려해야 함

            return randomDamage;
        }

        public int GetDamageValue(Monster monster)
        {
            // 공격력의 90% ~ 110% 사이의 랜덤 데미지 생성
            // to do: BattleManager같은 클래스를 만들어서 몬스터 데미지 시퀀스와 통합
            int maxDamage = (int)(monster.Attack * 1.1f);
            int minDamage = (int)(monster.Attack * 0.9f);

            Random random = new Random();

            int randomDamage = random.Next(minDamage, maxDamage + 1);   // to do: 추후 float로 바꿀 경우 nextdouble을 사용. maxDamage + 1 부분을 float일 경우 어떻게 할 것인지 고려해야 함

            return randomDamage;
        }

        public int GetHitDamageValue(int damage)
        {
            int result = 0;

            result = damage - GameManager.Instance.player.TotalDefense;

            if (result <= 0)
            {
                result = 0;
            }

            return result;
        }

        public int GetHitDamageValue(Monster monster, int damage)
        {
            int result = 0;

            // result = monster.Defense - damage; to do: 추후 몬스터에 defense 스테이터스가 생기면 적용
            result = damage;

            return result;
        }
    }
}
