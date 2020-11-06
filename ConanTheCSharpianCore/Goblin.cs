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

        public override void PerformSpecialAction()
        {
            float specialAccuracy = 2*Accuracy;
            float specialDamage = 0.75f*Damage;

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];
            
            if (_random.NextDouble() > specialAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} sniped {target.FullyQualifiedName} with his special attack for {specialDamage} damage.");
            target.CurrentHealth -= specialDamage;   
        }
        private static Random _random = new Random();
    }
}
