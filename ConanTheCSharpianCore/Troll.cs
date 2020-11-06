

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

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic

            DamageSp = Damage * 3;
            AccuracySp = Accuracy / 3;

            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
