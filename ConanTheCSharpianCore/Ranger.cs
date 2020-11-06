

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
        }

        private static Random _random = new Random();

        public override void PerformSpecialAction()
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target1 = validTargets[randomIndex];
            Character target2 = validTargets[randomIndex];
            Character target3 = validTargets[randomIndex];

            float spetialDamage = (float)(Damage * 0.75);
            float spetialAccuracy = Accuracy/2;
            
            if (target1.IsDead)
            {
                if (target2.IsDead)
                {
                    if (_random.NextDouble() > spetialAccuracy)
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target3.FullyQualifiedName}.");
                        return;
                    }
                    else
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target3.FullyQualifiedName} for {spetialDamage} damage.");
                        target3.CurrentHealth -= spetialDamage;
                    }
                }
                else
                {
                    if (_random.NextDouble() > spetialAccuracy)
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target2.FullyQualifiedName}.");
                        
                    }
                    else
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target2.FullyQualifiedName} for {spetialDamage} damage.");
                        target2.CurrentHealth -= spetialDamage;
                    }


                    if (_random.NextDouble() > spetialAccuracy)
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target3.FullyQualifiedName}.");
                        return;
                    }
                    else
                    {
                        Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target3.FullyQualifiedName} for {spetialDamage} damage.");
                        target3.CurrentHealth -= spetialDamage;
                    }

                    
                }
            }
            else
            {
                if (_random.NextDouble() > spetialAccuracy)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target1.FullyQualifiedName}.");
                }
                else
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target1.FullyQualifiedName} for {spetialDamage} damage.");
                    target1.CurrentHealth -= spetialDamage;
                }



                if (_random.NextDouble() > spetialAccuracy)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target2.FullyQualifiedName}.");
                }
                else
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target2.FullyQualifiedName} for {spetialDamage} damage.");
                    target2.CurrentHealth -= spetialDamage;
                }



                if (_random.NextDouble() > spetialAccuracy)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target3.FullyQualifiedName}.");
                    return;
                }
                else
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} successfully attacked {target3.FullyQualifiedName} for {spetialDamage} damage.");
                    target3.CurrentHealth -= spetialDamage;
                }
            }
            
        }
    }
}
