

using System;
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

        private static Random _random = new Random();

        public override void PerformSpecialAction()
        {
            float spetialDamage = (float)(0.75 * Damage);
            float spetialAccuracy = Accuracy*2;
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            if (_random.NextDouble() > spetialAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"Dammit! {FullyQualifiedName} attacked {target.FullyQualifiedName} for {spetialDamage} damage.");
            target.CurrentHealth -= spetialDamage;
        }
    }
}
