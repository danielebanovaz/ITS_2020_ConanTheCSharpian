using System.Collections.Generic;
using System.Linq;

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
            float lowestHealth = validTargets[0].CurrentHealth;
            int lowestHealthindex = 0;
            for (int i = 0; i < validTargets.Count; i++)
            {
                if (validTargets[i].CurrentHealth < lowestHealth)
                    lowestHealth = validTargets[i].CurrentHealth;
                lowestHealthindex = i;
            }

            Character target = validTargets[lowestHealthindex];

            Battlefield.DisplayMessage($"{FullyQualifiedName} is gathering his magic powers!");

            if (target == this)
                Battlefield.DisplayMessage($"{FullyQualifiedName} healed himself by 30hp.");
            else
                Battlefield.DisplayMessage($"{FullyQualifiedName} healed {target.FullyQualifiedName} by 30hp.");

            target.CurrentHealth += 30;
        }
    }
}
