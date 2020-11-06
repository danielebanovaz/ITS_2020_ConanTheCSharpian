

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
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            Damage = Damage*3;
            Accuracy =Accuracy*(1/3);
            PerformSpecialActionAttack();
            Damage = 50;
            Accuracy = 0.3f;
        }
    }
}
