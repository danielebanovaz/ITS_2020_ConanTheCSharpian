

using System;
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
        private static Random _random = new Random();

        public override void PerformSpecialAction()
        {
            float spetialDamage = 2 * Damage;
            float spetialAccuracy = Accuracy/2;
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            if (_random.NextDouble() > spetialAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return ;
            }
            
            Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target.FullyQualifiedName} for {spetialDamage} damage.");
            target.CurrentHealth -= spetialDamage;
        }
    }
}
