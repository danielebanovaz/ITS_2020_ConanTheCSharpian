

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        //ConsolePlayer consolePlayer = new ConsolePlayer();
        private static Random _random = new Random();
        public Warlock()
        {
            Name = "Saruman";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
            SpAccuracy = 0.5f;
            SpDamage = 20;
            SpCollateralDamage = 15;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");

            /*List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            List<Character> invalidTargets = Battlefield.GetInvalidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);


            if (_random.NextDouble() > SpAccuracy)
            {
                for (int i = 0; i < consolePlayer.numberOfMonsters; i++)
                {
                    Character target = invalidTargets[i];
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against the Hero Party, so he attacked his whole Monster Party for {SpCollateralDamage} damage.");
                    target.CurrentHealth -= SpCollateralDamage;
                    return;
                }
            }
            else
            {
                for (int i = 0; i < consolePlayer.numberOfAllies; i++)
                {
                    Character target = validTargets[randomIndex];
                    Battlefield.DisplayMessage($"{FullyQualifiedName} used his special attack against the whole Hero Party for {SpDamage} damage.");
                    target.CurrentHealth -= SpDamage;
                }
            }*/
        }
    }
}
