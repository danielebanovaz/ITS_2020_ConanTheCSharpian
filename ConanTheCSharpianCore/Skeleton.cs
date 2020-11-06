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
            Name = "Brook";
            Damage = 14;
            MaxHealth = 20;
            Accuracy = 0.6f;
            SpAccuracy = 1f;
        }
        public override void PerformSpecialAction()
        {
            throw new NotImplementedException();
        }
    }
}
