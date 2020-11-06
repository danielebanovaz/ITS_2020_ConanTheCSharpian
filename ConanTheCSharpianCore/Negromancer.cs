using System;

namespace ConanTheCSharpian.Core
{
    class Negromancer : Monster
    {
        private static Random _random = new Random();
        public Negromancer()
        {
            Name = "B";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.50f;
            MaxMana = 80;
        }
        public override void PerformSpecialAction()
        {
            int randomIndex = _random.Next(1, 4);
            CurrentMana -= 50;
            for (int i = 0; i < randomIndex; i++)
                Battlefield.CreateSkeleton();

            Battlefield.DisplayMessage($"{FullyQualifiedName} Create a skeleton.");
        }
    }
}
