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
        }

        public override void PerformSpecialAction()
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count);
            Character target = validTargets[randomIndex];

            Battlefield.DisplayMessage($"{FullyQualifiedName} is charging a mighty blow!");
            if (_random.NextDouble() > Accuracy / 2)
            {
                Battlefield.DisplayMessage($"...but missed his attack against {target.FullyQualifiedName} like a real noob.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} hit {target.FullyQualifiedName} at full force for {Damage*2} damage.");
            target.CurrentHealth -= Damage*2;
        }
    }
}
