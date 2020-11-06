

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            Name = "Drizzt";
            Damage = 15;
            MaxHealth = 85;
            Accuracy = 0.95f;
        }

        public override void PerformSpecialAction()
        {
            Random randomNumber = new Random();
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            /*for (int i = 0; i < 3; i++)
            {
                
               List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
                int randomIndex = randomNumber.Next(0, validTargets.Count - 1);
               Character target = validTargets[randomIndex];
               //target.CurrentHealth -= Damage;
            }*/
  
        }
    }
}
