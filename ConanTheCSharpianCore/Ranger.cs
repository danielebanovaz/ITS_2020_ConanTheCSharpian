

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            Damage = 15;
            MaxHealth = 85;
            Accuracy = 0.95f;
        }

        protected override void PerformSpecialAction()
        {
            List<Character> opponents = Battlefield.GetValidTargets(this, TargetType.Opponents);

            int amountToTake = 3;
            if (opponents.Count < amountToTake)
                amountToTake = opponents.Count;

            List<Character> targets = new List<Character>(amountToTake);

            while (targets.Count < amountToTake)
            {
                Character newTarget = Helpers.GetRandomElement(opponents);
                if (!targets.Contains(newTarget))
                    targets.Add(newTarget);
            }

            foreach (Character target in targets)
                Attack(target, Damage * 0.75f, Accuracy * 0.5f, "Triple shoot: ");
        }
    }
}
