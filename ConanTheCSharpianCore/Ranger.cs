

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
            //List<Character> targets = new List<Character>();
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = _random.Next(0, validTargets.Count - 1);
                Character target = validTargets[randomIndex];
        
                if (_random.NextDouble() > Accuracy / 2)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                    return;
                }

                Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} for {Damage * 0.75} damage.");
                target.CurrentHealth -= Damage * (75 / 100);
            }
        }
    }
}
