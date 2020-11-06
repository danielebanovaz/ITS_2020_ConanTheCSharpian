using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "Skeleton";
            Damage = 14;
            MaxHealth = 20;
            Accuracy = 0.6f;

        }


        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}

