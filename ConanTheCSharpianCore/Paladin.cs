

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Paladin : Hero
    {
        private float _blessBoost = 1.75f;

        public Paladin()
        {
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            MaxMana = 50;
            ManaConsumption = 30;
        }

        protected override void PerformSpecialAction()
        {
            List<Character> allies = Battlefield.GetValidTargets(this, TargetType.Allies);

            allies.Remove(this);
            foreach (Character ally in allies)
                ally.NextBaseAttackBoost = _blessBoost;

            Battlefield.DisplayMessage($"{FullyQualifiedName} blessed his allies! On the next base attack, {string.Join(", ", allies)} will do {_blessBoost}x damage.");
        }
    }
}
