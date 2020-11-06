
//ASSIGNMENT 3

namespace ConanTheCSharpian.Core
{
    public class Necromancer : Monster
    {
        public Necromancer()
        {
            Name = "Hotus";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.5f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
