using System;

namespace ConanTheCSharpian.Core
{
    public class Barbarian : Hero
    {
        private static Random _random = new Random();
        public Barbarian()
        {
            Name = "Conan";
            Damage = 30;
            MaxHealth = 120;
            Accuracy = 0.6f;
        }

        public override void PerformSpecialAction()
        {
            float _damageForThisAction = Damage * 2f;
            float _accuracyForThisAction = Accuracy * 0.5f;
            
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
