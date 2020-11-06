using System.Collections.Generic;
using System.Linq;

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
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            
            int randomIndex = -1;
            Character target = null;
            int[] targetIndexes = { -1, -1, -1 };
            Battlefield.DisplayMessage($"{FullyQualifiedName} is loading his bow for a triple shot!");
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    randomIndex = _random.Next(0, validTargets.Count); //needs fixing, when the remaining characters are a few
                } while (targetIndexes.Contains(randomIndex));

                targetIndexes[i] = randomIndex;
                target = validTargets[randomIndex];
                if (_random.NextDouble() > Accuracy / 2)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName}'s arrow missed {target.FullyQualifiedName}.");
                    continue;
                }

                Battlefield.DisplayMessage($"{FullyQualifiedName}'s arrow hit {target.FullyQualifiedName} for {Damage * 0.75} damage.");
                target.CurrentHealth -= Damage * 0.75f;
            }
        }
    }
}
