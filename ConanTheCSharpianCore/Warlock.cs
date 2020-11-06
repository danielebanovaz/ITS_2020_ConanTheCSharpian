

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        public Warlock()
        {
            Name = "Saruman";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            var _random = new System.Random();
            List<Character> allies = Battlefield.GetValidTargets(this, TargetType.Allies);
            List<Character> ValidTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int r = _random.Next(0, 1);
            if (r == 0)
            {
                for (int i = 0; i < ValidTargets.Count; i++)
                {
                    ValidTargets[i].CurrentHealth = ValidTargets[i].CurrentHealth - 20;
                }
                Battlefield.DisplayMessage($"{FullyQualifiedName} just attacked all the opponents for 20 damage!");
            }
            if (r == 1)
            {
                for (int i = 0; i < allies.Count; i++)
                {
                    allies[i].CurrentHealth = allies[i].CurrentHealth - 20;
                }
                Battlefield.DisplayMessage($"{FullyQualifiedName} just missed the opponents and attacked all the allies for 15 damage!");
            }
            
            //Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
        }
    }
}
