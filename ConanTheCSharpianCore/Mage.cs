

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

        public void PerformSpecialAction()
        {
            // TODO: implement special action logic

            MaxHealth = MaxHealth + 30;
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
