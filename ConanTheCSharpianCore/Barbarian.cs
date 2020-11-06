

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
            Damage = Damage * 2;
            Accuracy = Accuracy / 2; 
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
