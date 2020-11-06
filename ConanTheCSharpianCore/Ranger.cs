

using System;
using System.Collections.Generic;

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
            UsedPaladinEffect = false;
        }


        public override void PerformSpecialAction()
        {
            Random random = new Random();

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex;
        
           


            if (validTargets.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    randomIndex = random.Next(0, validTargets.Count - 1);
                    Character target = validTargets[randomIndex];

                    if (random.NextDouble() > Accuracy / 2)
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} throw a arrow at {target.FullyQualifiedName} but he missed.");

                    }
                    else
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} throw a arrow at {target.FullyQualifiedName} for {Damage * 0.75f} damage.");
                        target.CurrentHealth -= Damage * 0.75f;
                    }


                }
             
  }
            else
            {
               foreach(Character target in validTargets)
                {
                    if (random.NextDouble() > Accuracy / 2)
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} throw a arrow at {target.FullyQualifiedName} but he missed.");
                    }
                    else
                    {

                        Battlefield.DisplayMessage($"{FullyQualifiedName} throw a arrow at {target.FullyQualifiedName} for {Damage * 0.75f} damage.");
                        target.CurrentHealth -= Damage * 0.75f;
                    }
                }
            }
          
        }
    }
}
