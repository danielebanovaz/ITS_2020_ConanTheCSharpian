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
            Name = "Sir.John";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.70f;
            Maxmana = 50;
        }
        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
       
    
}
