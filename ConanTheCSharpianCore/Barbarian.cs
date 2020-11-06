

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

        public void PerformSpecialAction()
        {
            // TODO: implement special action logic

            Damage = 60;
            Accuracy = 0.3f;

            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
