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
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count);
            Character target = validTargets[randomIndex];

            Battlefield.DisplayMessage($"{FullyQualifiedName} goes for a precise hit!");
            if (_random.NextDouble() > Accuracy * 2)
            {
                Battlefield.DisplayMessage($"...and yet managed to miss {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} hit {target.FullyQualifiedName} for {Damage * 0.75} damage.");
            target.CurrentHealth -= Damage * 0.75f;
        }
    }
}
