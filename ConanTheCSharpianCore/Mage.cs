

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
            UsedPaladinEffect = false;
        }

       

        public override void PerformSpecialAction()
        {
            Random random = new Random();

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
            int randomIndex = random.Next(0, validTargets.Count - 1);
            Character choosenTarget = this;


            foreach (Character target in validTargets)
            {
             
                if(choosenTarget.CurrentHealth < target.CurrentHealth) 
                {
                    choosenTarget = target;
                }

            }
            
  

            Battlefield.DisplayMessage($"{FullyQualifiedName} used a potion at {choosenTarget.FullyQualifiedName} for { 30} health .");
            choosenTarget.CurrentHealth += 30;
        }
    }
}
