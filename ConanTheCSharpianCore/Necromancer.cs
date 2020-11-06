

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Necromancer : Monster
    {
        public Necromancer()
        {
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.5f;
            MaxMana = 80;
            ManaConsumption = 50;
        }

        protected override void PerformSpecialAction()
        {
            int randomAmount = Random.Next(1, 4);

            for (int i = 0; i < randomAmount; i++)
                Battlefield.Monsters.CreateNewCharacter(CharacterType.Skeleton, Battlefield.AiController, Battlefield);

            Battlefield.DisplayMessage($"{FullyQualifiedName} has just raised {randomAmount} Skeleton{(randomAmount > 1 ? "s" : string.Empty)} from the dead!");
        }
    }
}
