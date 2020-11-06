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
            Name = "Uther";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            MaxMana = 50;
            CurrentMana = 0;
        }
       public override void PerformSpecialAction()
        {
            if (CurrentMana > 30) 
            {
                CurrentMana -= 30;
              
                Battlefield.DisplayMessage($"{FullyQualifiedName} just use his special ability ,improved attack Squad (1.75%)");
                
                Battlefield.PaladinEffect = true;
            }
            else
            {
                this.CurrentMana = CurrentMana + 10;
                  Console.ResetColor();
                this.PerformBaseAttack();

            }
        }
       
    }
}
