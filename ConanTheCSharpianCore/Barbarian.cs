

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Barbarian : Hero
    {
        
        public Barbarian()
        {
            Name = "Conan";
            Damage = 30;
            MaxHealth = 120;
            Accuracy = 0.6f;
            UsedPaladinEffect = false;
       
        }

  
        public override void PerformSpecialAction()
        {

            Random random = new Random();

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = random.Next(0, validTargets.Count - 1);

            Character target = validTargets[randomIndex];

            if (random.NextDouble() > Accuracy/2)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} throw a bolder at {target.FullyQualifiedName} but he missed.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} throw a bolder at {target.FullyQualifiedName} for {Damage * 2} damage.");
            target.CurrentHealth -= Damage * 2;

        }
    }
}
