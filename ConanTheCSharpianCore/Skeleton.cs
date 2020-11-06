using System;
using System.Collections.Generic;
namespace ConanTheCSharpian.Core
{
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "Skeletor";
            Damage = 14;
            MaxHealth = 20;
            Accuracy = 0.6f;
        }

        public override void PerformSpecialAction()
        {
            this.CurrentHealth -= 4;
        }
    }
}
