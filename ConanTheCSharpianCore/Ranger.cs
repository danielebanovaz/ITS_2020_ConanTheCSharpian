

namespace ConanTheCSharpian.Core
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            Name = "Drizzt";
            Damage = 15;
            MaxHealth = 85;
            Accuracy = 0.95f;
        }

        public void PerformSpecialAction()
        {
            // TODO: implement special action logic

            Damage = 15 * 0.75f;
            Accuracy = 0.98f / 2;

            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
