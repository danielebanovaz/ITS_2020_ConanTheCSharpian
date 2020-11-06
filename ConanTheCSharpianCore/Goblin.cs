

namespace ConanTheCSharpian.Core
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Creld";
            Damage = 20;
            MaxHealth = 85;
            Accuracy = 0.8f;
        }

        public void PerformSpecialAction()
        {
            // TODO: implement special action logic

            Damage = 20 * 0.75f;
            Accuracy = 1;
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
