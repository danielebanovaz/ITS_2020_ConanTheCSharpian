

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
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            Damage = Damage-(25/100);
            Accuracy = Accuracy*2;
            PerformSpecialActionAttack();
            Damage = 20;
            Accuracy = 0.8f;
        }
    }
}
