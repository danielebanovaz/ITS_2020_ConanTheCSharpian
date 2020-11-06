using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    class Paladin : Hero
    {
        
        public Paladin()
        {
            Name = "Andrea";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            mana = 50;
            manacost = 30;
        }
        public override void PerformSpecialAction()
        {
            mana =-manacost;
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
            foreach (var allie in validTargets)
            {
                allie.damageIncrease = 0.75f;
            }
            
        }
    }
}
