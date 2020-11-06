

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Creld";
            Damage = 20;
            MaxHealth = 85;
            Accuracy = 0.8f;
        }

   

        public override void PerformSpecialAction()
        {
            Random random = new Random();

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = random.Next(0, validTargets.Count - 1);

            Character target = validTargets[randomIndex];

            if (random.NextDouble() > Accuracy * 2)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} hits with a hammer {target.FullyQualifiedName} but he missed.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName}hits with a hammer {target.FullyQualifiedName} for {Damage * 0.75f} damage.");
            target.CurrentHealth -= Damage * 0.75f;
        }
    }
}
