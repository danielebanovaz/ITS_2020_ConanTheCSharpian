
//ASSIGNMENT 3

namespace ConanTheCSharpian.Core
{
    public class Paladin : Hero
    {
        public Paladin()
        {
            Name = "Lancilot";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}