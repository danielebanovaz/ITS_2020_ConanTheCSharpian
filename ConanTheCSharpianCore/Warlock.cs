

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        private float _spellDamage = 15;
        public Warlock()
        {
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
        }

        protected override void PerformSpecialAction()
        {
            bool success = Random.NextDouble() > 0.5f;
            TargetType targetType = success ? TargetType.Opponents : TargetType.Allies;

            List<Character> targets = Battlefield.GetValidTargets(this, targetType);
            Battlefield.DisplayMessage($"{FullyQualifiedName} {(success ? "successfully casted" : "failed to cast")} a fireball spell! {string.Join(", ", targets)} damaged by {_spellDamage}.");

            foreach (Character target in targets)
                target.CurrentHealth -= _spellDamage;
        }
    }
}
