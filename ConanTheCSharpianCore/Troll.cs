using System;

namespace ConanTheCSharpian.Core
{
    public class Troll : Monster
    {
        private static Random _random = new Random();
        public Troll()
        {
            Name = "Durgh";
            Damage = 50;
            MaxHealth = 160;
            Accuracy = 0.3f;
        }

        public override void PerformSpecialAction()
        {
            float _damageForThisAction = Damage * 3f;
            float _accuracyForThisAction = Accuracy * 0.33f;

            Character target = ChooseTarget();

            if (_random.NextDouble() > _accuracyForThisAction)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his special attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} with his SPECIAL ATTACK for {_damageForThisAction} damage.");
            //target.CurrentHealth -= _damageForThisAction;
            ReduceTargetHealth(target, _damageForThisAction);
        }
    }
}
