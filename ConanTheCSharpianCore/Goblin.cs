

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Goblin : Monster
    {
        private static Random _random = new Random();
        public Goblin()
        {
            Name = "Creld";
            Damage = 20;
            MaxHealth = 85;
            Accuracy = 0.8f;
            SpAccuracy = 1;
            SpDamage = Damage / 4 * 3;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);

            Character target = validTargets[randomIndex];

            if (_random.NextDouble() > SpAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} used his special attack against {target.FullyQualifiedName} for {SpDamage} damage.");
            target.CurrentHealth -= SpDamage;
        }
    }
}
