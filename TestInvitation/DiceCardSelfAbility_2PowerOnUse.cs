using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvitation
{
    //DiceCardSelf is for Card effects.
    public class DiceCardSelfAbility_2PowerOnUse : DiceCardSelfAbilityBase
    {
        public static string Desc = "[On Use] All dice on this card gain +2 Power.";
        public override void OnUseCard()
        {
            /* dmg is damage increase
             * breakDmg is stagger damage increase
             * dmgRate and breakRate are percentage increases instead
             * dmgRate = -9999 and breakRate = -9999 is how Cobalt scar does no damage or stagger damage on hit.
             * just use commas to add more stat bonuses.
             */
            this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus()
            {
                power = 2
            });
        }
    }
}
