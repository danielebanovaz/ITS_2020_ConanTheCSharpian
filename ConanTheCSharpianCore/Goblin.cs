using System;

namespace ConanTheCSharpian.Core
{
    public class Goblin : Monster
    {
        private static Random _random = new Random();
        public Goblin()
        {
            Name = "Creld";
            Damage = 20;
            MaxHealth = 85;
            Accuracy = 0.8f;
        }

        public override void PerformSpecialAction()
        {
            float _damageForThisAction = Damage * 0.75f;
            float _accuracyForThisAction = Accuracy * 2f;

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
