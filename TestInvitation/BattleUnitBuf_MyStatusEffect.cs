using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInvitation
{
    //BattleUnitBuf is for Status effects.
    public class BattleUnitBuf_MyStatusEffect : BattleUnitBuf
    {
        //This value should always be unique between mods.
        protected override string keywordId => "MyFairyModMusic";
        //This is the Base game icon I found from Tiphereth Database under Effects
        //If you have Base Mod you can add custom icons but I will talk about that in a later video.
        protected override string keywordIconId => "ArgaliaUpsurge";
        //This is if the buff is a positive or negative effect. Warning if it is negative PT can ignore it with Guard Stance.
        //I belive if you leave this blank or BufPositiveType.None it is considered neutral.
        public override BufPositiveType positiveType => BufPositiveType.Negative;

        //This is what the buff says when you hover over it.
        public override string bufActivatedText
        {
            get
            {
                //The $ let's you write code in the description. In this case the {this.stack} will check how much of the buff the user has and display that number.
                //By base however the game says how many stacks you have so this is just to show off that you can do this. You can also do math and things if you want just stay inside the {}.
                return $"'Music': You have {this.stack} Music stacks. This status can't go over 8.";
            }
        }

        //This is important for making sure your buff has a Maximum (or minimum if you want that) value.
        public override void OnAddBuf(int addedStack)
        {
            //Math.Min will choose the lower of the two numbers, so if the new stack would be greater than 8 it is equal to 8 instead.
            this.stack = Math.Min(this.stack + addedStack, 8);
        }

        public override void OnRoundEnd()
        {
            //this lowers the stack by 1 each Scene End.
            this.stack--;

            //If the stack is 0 or less it will destroy the buff removing it completely.
            if (this.stack <= 0)
            {
                this.Destroy();
            }
        }
    }
}

