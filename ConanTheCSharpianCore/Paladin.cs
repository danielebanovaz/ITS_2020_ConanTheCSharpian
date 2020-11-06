using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public class Paladin : Hero
    {
        public Paladin()
        {
            Name = "Athos";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            MaxMana = 50;
            ManaCost = 30;
            SpAccuracy = 1;
        }
        public override void PerformSpecialAction()
        {
            

            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
