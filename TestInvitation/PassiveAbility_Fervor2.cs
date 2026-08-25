using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvitation
{
    //PassiveAbility is for passive effects.
    public class PassiveAbility_Fervor2 : PassiveAbilityBase
    {
        //I don't believe Desc does anything here but it can be helpful for you and others understanding what the passive does.
        public static string Desc = "Offensive Dice Allways gain 1 Power.";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            //This was the old condition I changed for Fervor.
            //if (IsAttackDice(behavior.Detail) && owner.emotionDetail.EmotionLevel >= 3)
            //&& means both must be true, but || means only one needs to be true.
            //if (IsAttackDice(behavior.Detail) || owner.emotionDetail.EmotionLevel >= 3)
            //So the above condition would work for attack dice always, or for all dice at emotion level 3 or higher.
            if (IsAttackDice(behavior.Detail))
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 1
                });
            }
        }
    }
}
