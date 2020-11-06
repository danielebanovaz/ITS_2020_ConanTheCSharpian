using System;
using System.Collections.Generic;
namespace ConanTheCSharpian.Core
{
    public class Mage : Hero
    {
        public Mage()
        {
            Name = "Vlad";
            Damage = 18;
            MaxHealth = 50;
            Accuracy = 0.85f;
        }

        public override void PerformSpecialAction()
        {
            float heal = 30;
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies); //NON SO PERCHè CRASHA
            Character lowestHealthChar = null;
            float min = 1000;
            foreach(Character t in validTargets)
            {
                if (t.CurrentHealth< min)
                {
                    min = t.CurrentHealth;
                    lowestHealthChar = t;
                }
            }
    
            Battlefield.DisplayMessage($"{FullyQualifiedName} healed {lowestHealthChar.FullyQualifiedName} for {heal} hp with his special attack.");
            lowestHealthChar.CurrentHealth += heal; 

        }
    }
}
