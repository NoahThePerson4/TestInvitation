using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PassiveAbility_150238;

namespace TestInvitation
{
    //This is inflicting the new effect.
    public class DiceCardAbility_InflictNewStatus : DiceCardAbilityBase
    {
        public static string Desc = "[On Hit] Inflict 5 Music.";

        public override void OnSucceedAttack(BattleUnitModel target)
        {
            //This finds the amount of the buff on the target of the dice.
            //Simply change target for all of these to owner to apply it to yourself.
            BattleUnitBuf battleUnitBuf = target.bufListDetail.GetActivatedBufList()
            .Find((Predicate<BattleUnitBuf>)(x => x is BattleUnitBuf_MyStatusEffect));

            //If the value is null (so it doesn't exist) then a new copy of the buff is made with 5 stacks.
            if (battleUnitBuf == null)
            {
                battleUnitBuf = new BattleUnitBuf_MyStatusEffect()
                {
                    stack = 5
                };
                target.bufListDetail.AddBuf(battleUnitBuf);
            }

            //Otherwise the stack is run through OnAddBuff to add 5 to it but still enforce the Max stack of 8.
            else
            {
                battleUnitBuf.OnAddBuf(5);
            }

        }
    }
}
