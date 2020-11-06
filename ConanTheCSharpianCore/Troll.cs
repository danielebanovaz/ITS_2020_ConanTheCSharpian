

namespace ConanTheCSharpian.Core
{
    public class Troll : Monster
    {
        public Troll()
        {
            Name = "Durgh";
            Damage = 50;
            MaxHealth = 160;
            Accuracy = 0.3f;
        }

        public  void PerformSpecialAction()
        {
            // TODO: implement special action logic

            Damage = 150;
            Accuracy = 0.15f;
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
