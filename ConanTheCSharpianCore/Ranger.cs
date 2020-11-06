using System.Collections.Generic;
using System;

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

        private static Random _random = new Random();
        public override void PerformSpecialAction()
        {
            float specialAccuracy = 0.5f*Accuracy;
            float specialDamage = 0.75f*Damage;
            int hits = 3;
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);

            switch (validTargets.Count){
                case 1: hits = 1;
                        break;
                case 2: hits = 2;
                        break;
                case 0: hits = 0;
                        break;
                default: hits = 3;
                    break;
            }                
            
           int randomIndex =0;
            for(int i = 0; i < hits; i++)
            {  
                randomIndex = _random.Next(0, validTargets.Count - 1);
            
                Character target = validTargets[randomIndex];

                if (_random.NextDouble() > specialAccuracy)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack {i}. shot against {target.FullyQualifiedName}.");
                }
                else
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} shot {target.FullyQualifiedName} for {specialDamage} damage. ({i}. shot)");
                    target.CurrentHealth -= specialDamage;
                }
            }            
        }
    }
}
