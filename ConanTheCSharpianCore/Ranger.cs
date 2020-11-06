

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

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic

            DamageSp = Damage * 0.75f;
            AccuracySp = Accuracy * 0.5f;
            // TODO: implement target x 3

            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
