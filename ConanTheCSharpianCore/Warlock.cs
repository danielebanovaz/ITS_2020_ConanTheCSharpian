using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        private static Random _random = new Random();
        public Warlock()
        {
            Name = "Saruman";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
        }

        public override void PerformSpecialAction()
        {
            float _damageForThisAction = Damage * 2f;
            float _accuracyForThisAction = Accuracy * 0.5f;
            if (_random.NextDouble() > _accuracyForThisAction)
            {
                List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Allies);
                _damageForThisAction = 15;
                foreach(Character target in validTargets)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} with his SPECIAL ATTACK for {_damageForThisAction} damage.");
                    ReduceTargetHealth(target, _damageForThisAction);
                }
            }
            else
            {
                List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
                _damageForThisAction = 20;
                foreach (Character target in validTargets)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} with his SPECIAL ATTACK for {_damageForThisAction} damage.");
                    ReduceTargetHealth(target, _damageForThisAction);
                }
            }
        }
    }
}
