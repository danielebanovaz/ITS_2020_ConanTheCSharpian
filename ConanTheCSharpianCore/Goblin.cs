

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

        public override void PerformSpecialAction()
        {
            Damage = Damage * 0.75f;
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
