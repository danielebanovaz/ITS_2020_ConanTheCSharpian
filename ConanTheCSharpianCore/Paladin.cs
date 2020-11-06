

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Paladin : Hero
    {
        public Paladin()
        {
            Name = "Sigmund";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            MaxMana = 50;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            DamageSp = Damage;
            AccuracySp = Accuracy;

            

            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action with double damage!");
        }
    }
}
