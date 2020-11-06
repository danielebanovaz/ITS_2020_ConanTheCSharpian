using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    class Paladin : Hero
    {
        public Paladin()
        {
            Name = "A";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.70f;
            MaxMana = 50;
        }

        public override void PerformSpecialAction()
        {
            CurrentMana -= 30;
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
