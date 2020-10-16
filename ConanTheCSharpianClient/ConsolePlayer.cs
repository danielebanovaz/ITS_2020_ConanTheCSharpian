

using ConanTheCSharpian.Core;
using System;

namespace ConanTheCSharpian.Client
{
    public class ConsolePlayer : ICharacterController
    {
        public CharacterType ChooseHeroCategory()
        {
            while (true)
            {
                Console.WriteLine(@"Choose your character's class:
- [B]arbarian
- [R]anger
- [M]age");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "b":
                    case "barbarian":
                        return CharacterType.Barbarian;

                    case "r":
                    case "ranger":
                        return CharacterType.Ranger;

                    case "m":
                    case "mage":
                        return CharacterType.Mage;
                }
            }
        }

        public string ChooseHeroName()
        {
            string name;
            do
            {
                Console.WriteLine("Choose your character's name:");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void ChooseAttackType(Character controlledCharacter)
        {
            while (true)
            {
                Console.WriteLine($"It's time for {controlledCharacter.FullyQualifiedName} to act. Please choose his action between [B]ase attack and [S]pecial action:");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "b":
                        controlledCharacter.PerformBaseAttack();
                        return;

                    case "s":
                        controlledCharacter.PerformSpecialAction();
                        return;
                }

                Console.WriteLine("Invalid option. Please digit 'B' for Base attack and 'S' for Special action");
            }
        }
    }
}
