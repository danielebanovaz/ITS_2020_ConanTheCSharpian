

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Mage : Hero
    {
        public Mage()
        {
            Name = "Vlad";
            Damage = 18;
            MaxHealth = 50;
            Accuracy = 0.85f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            //CurrentHealth = CurrentHealth + 30;
            
            List<Character> helpAllies = Battlefield.GetValidTargets(this, TargetType.Allies);
            for(int i=0; i<helpAllies.Count; i++)
            {
                helpAllies[i].CurrentHealth = helpAllies[i].CurrentHealth + 30;
            }
            Battlefield.DisplayMessage($"{FullyQualifiedName} just added 30 of health at all his faction!");
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
