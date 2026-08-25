using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvitation
{
    //DiceCardAbility is for Dice effects.
    public class DiceCardAbility_Inflict2BleedOnHit: DiceCardAbilityBase
    {
        //The [] will have the text be in bold.
        public static string Desc = "[On Hit] Inflict 2 Bleed next turn.";

        //These are the Keywords on the card. To add more just increase string[1] to a higher number and seperate with commas.

        public override string[] Keywords => new string[1]
        {
            "Bleeding_Keyword"
        };

        //This is On Hit.
        public override void OnSucceedAttack()
        {
            //Change this to AddKeywordBufThisRoundByCard for same scene infliction.
            //I will be honest I don't know what the this.owner is for but I always add it just in case.
            //Change it to ByEtc to have it not be considered a card ability so things like Yang's passive won't buff it.
            this.card.target?.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 2, this.owner);
        }
    }
}
