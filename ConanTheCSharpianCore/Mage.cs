

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

            Character target = ChooseLowerHealthAlly();

            Battlefield.DisplayMessage($"{FullyQualifiedName} heals {target.FullyQualifiedName} with his SPECIAL ATTACK");
            //target.CurrentHealth -= _damageForThisAction;
            ReduceTargetHealth(target, -30);
        }
    }
}
