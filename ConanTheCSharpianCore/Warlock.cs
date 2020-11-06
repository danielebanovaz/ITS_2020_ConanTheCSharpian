

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
            Random random = new Random();
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = random.Next(0,2);

            switch (randomIndex)
            {
                case (0):
                    Battlefield.DisplayMessage($"{FullyQualifiedName} used a hellfire at the Heroes hitting them for {30} damage .");
                    foreach (Character target in validTargets)
                    {
                        target.CurrentHealth -= 20;
                    }
                    break;

                case (1):
                         Battlefield.DisplayMessage($"{FullyQualifiedName} used a hellfire at the Heroes but he lost control of it and hits the Monsters for { 15} damage .");
                   
                    validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
                            foreach (Character target in validTargets)
                            {
                                target.CurrentHealth -= 15;
                            }
                    break;
            }
            Character choosenTarget = this;


        


        }
    }
}
