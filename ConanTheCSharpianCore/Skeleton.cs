using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "C";
            Damage = 14;
            MaxHealth = 20;
            Accuracy = 0.6f;
        }
        public override void PerformSpecialAction()
        {
            this.MaxHealth -= 4;
        }
    }
}
