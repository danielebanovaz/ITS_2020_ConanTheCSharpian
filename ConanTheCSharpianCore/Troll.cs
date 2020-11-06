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
            float SpecialAccuracy = (1/3)*Accuracy;
            float SpecialDamage = 3*Damage;

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];
            
            if (_random.NextDouble() > SpecialAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} super *bonked* {target.FullyQualifiedName} with his special attack for {SpecialDamage} damage.");
            target.CurrentHealth -= SpecialDamage;
        }
        private static Random _random = new Random();
    }
}
