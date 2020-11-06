

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
            // TODO: implement special action logic
            var _random = new System.Random();
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            Battlefield.DisplayMessage($"{FullyQualifiedName} now will attack 3 random opponents!");
            for(int i=0; i<3; i++)
            {
                int randomIndex = _random.Next(0, validTargets.Count - 1);
                Character target = validTargets[randomIndex];

                if (_random.NextDouble() > Accuracy / 2)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his {i} special attack against {target.FullyQualifiedName}.");
                }
                else
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} used his {i} special attack on {target.FullyQualifiedName} for {Damage * 0.75} damage!");
                    target.CurrentHealth -= Damage * 0.75f;
                }
            }
            
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
