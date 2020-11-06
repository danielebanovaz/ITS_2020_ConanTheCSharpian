using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Ranger : Hero
    {
        private static Random _random = new Random();
        public Ranger()
        {
            Name = "Drizzt";
            Damage = 15;
            MaxHealth = 85;
            Accuracy = 0.95f;
        }

        public override void PerformSpecialAction()
        {
            List<Monster> targets = new List<Monster>();
            float _damageForThisAction = Damage * 0.75f;
            float _accuracyForThisAction = Accuracy * 0.5f;

            Monster target;
            for(int i=0; i<3; i++)
            {
                do
                {
                    target = (Monster)ChooseTarget();
                } while (targets.Contains(target));
                if (_random.NextDouble() > _accuracyForThisAction)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                    return;
                }
            }
        }
    }
}
