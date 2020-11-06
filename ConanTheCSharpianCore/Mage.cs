

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Mage : Hero
    {
        public Mage()
        {
            Name = "Vlad";
            Damage = 18;
            MaxHealth = 50;
            Accuracy = 0.85f;
        }

        public override void PerformSpecialAction()
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];

            if (_random.NextDouble() > Accuracy )
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} just use his curative's power!");
                return;
            }
            if(target ==this)
                Battlefield.DisplayMessage($"{FullyQualifiedName} just heal himself with 30 hp!");
            else
            Battlefield.DisplayMessage($"{FullyQualifiedName} just heal {target.FullyQualifiedName} with 30 hp");
            target.CurrentHealth += 30;

        
    }
    }
}
