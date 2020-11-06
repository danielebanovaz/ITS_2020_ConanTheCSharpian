using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        public Warlock()
        {
            Name = "Saruman";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
        }

        public override void PerformSpecialAction()
        {

            float enemyDamage = 20;
            float allyDamage = 15;
            Boolean randomChance=false;
            if(_random.Next(0, 10)>=5)randomChance = true;

            if(randomChance)
            {  
               Battlefield.DisplayMessage($"{FullyQualifiedName} fireballed all alive enemies with his special move");
               List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);           
               foreach(Character target in validTargets)
                {
                     Battlefield.DisplayMessage($"{target.FullyQualifiedName} got bruned for {enemyDamage} damage.");
                    target.CurrentHealth -= enemyDamage;
                }
            }else
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} fireballed his own allies and himself ");
                List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);           
                foreach(Character target in validTargets)
                {
                     Battlefield.DisplayMessage($"{target.FullyQualifiedName} got bruned for {allyDamage} damage.");
                    target.CurrentHealth -= allyDamage;
                }
            }
        }
        private static Random _random = new Random();
    }
}
