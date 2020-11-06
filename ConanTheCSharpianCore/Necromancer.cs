using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public class Necromancer : Monster
    {

    
         public Necromancer()
    {
        Name = "Durza";
        Damage = 15;
        MaxHealth = 70;
        Accuracy = 0.5f;
    }

    public override void PerformSpecialAction()
        {
        // TODO: implement special action logic
        Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }      
    }
}
