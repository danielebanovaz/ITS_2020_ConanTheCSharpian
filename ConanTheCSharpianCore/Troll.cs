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
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count);
            Character target = validTargets[randomIndex];

            Battlefield.DisplayMessage($"{FullyQualifiedName} is charging a killer blow!");
            if (_random.NextDouble() > Accuracy / 3)
            {
                Battlefield.DisplayMessage($"...but missed his attack against {target.FullyQualifiedName} like a dumbass.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} hit {target.FullyQualifiedName} at full force for {Damage * 3} damage.");
            target.CurrentHealth -= Damage * 3;
        }
    }
}
