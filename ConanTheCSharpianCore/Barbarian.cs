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

        public override void PerformSpecialAction()
        {   
            float specialAccuracy = 0.5f*Accuracy;
            float specialDamage = 2*Damage;

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];
            
            if (_random.NextDouble() > specialAccuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} bonked {target.FullyQualifiedName} with his special attack for {specialDamage} damage.");
            float currentHealth = target.CurrentHealth;
            currentHealth -= specialDamage;
            target.CurrentHealth -= specialDamage;  
        }

        private static Random _random = new Random();
    }
}
