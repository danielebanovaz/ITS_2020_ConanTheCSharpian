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
            List<Character> validTargets;
            int randomIndex = _random.Next(0, 2);
            int damage = 0;

            Battlefield.DisplayMessage($"{FullyQualifiedName} is about to unleash his magical powers!");

            if (randomIndex == 0)
            {
                validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
                damage = 20;
            }
            else
            {
                validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
                damage = 15;
            }

            foreach (Character target in validTargets)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} hit {target.FullyQualifiedName} for 20 damage.");
                target.CurrentHealth -= damage;
            }
        }
    }
}
