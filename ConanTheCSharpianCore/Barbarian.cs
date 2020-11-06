

namespace ConanTheCSharpian.Core
{
    public class Barbarian : Hero
    {
        public Barbarian()
        {
            Name = "Conan";
            Damage = 30;
            MaxHealth = 120;
            Accuracy = 0.6f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            Damage = Damage * 2;
            Accuracy = Accuracy / 2;
            PerformSpecialActionAttack();
            Damage = 30;
            Accuracy = 0.6f;
        }
    }
}
