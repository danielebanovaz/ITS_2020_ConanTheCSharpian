

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Mage : Hero
    {
        private float _healAmount = 30;

        public Mage()
        {
            Damage = 18;
            MaxHealth = 50;
            Accuracy = 0.85f;
        }

        protected override void PerformSpecialAction()
        {
            List<Character> allies = Battlefield.GetValidTargets(this, TargetType.Allies);

            Character target = null;
            float lowerHealth = float.MaxValue;

            foreach (Character ally in allies)
            {
                if (ally.CurrentHealth >= lowerHealth)
                    continue;

                lowerHealth = ally.CurrentHealth;
                target = ally;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} healed {target} for {_healAmount} hp.");

            target.CurrentHealth += _healAmount;
        }
    }
}
