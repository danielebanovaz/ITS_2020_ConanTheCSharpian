

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Troll : Monster
    {
        public Troll()
        {
            Name = "Durgh";
            Damage = 50;
            MaxHealth = 160;
            Accuracy = 0.3f;
        }

    

        public override void PerformSpecialAction()
        {
            Random random = new Random();

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = random.Next(0, validTargets.Count - 1);

            Character target = validTargets[randomIndex];

            if (random.NextDouble() > Accuracy / 3)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} launch a meteor at {target.FullyQualifiedName} but he missed.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName}  launch a meteor at  {target.FullyQualifiedName} for {Damage * 3} damage.");
            target.CurrentHealth -= Damage * 3;
        }
    }
}
