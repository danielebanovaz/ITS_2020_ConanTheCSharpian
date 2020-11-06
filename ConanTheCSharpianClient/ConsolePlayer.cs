

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
- [M]age
- [P]aladin");
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

                    case "p":
                    case "paladin":
                        return CharacterType.Paladin;
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

        public int ChooseCharactersNumber(int min, string type)
        {
            int amount;
            do
            {
                Console.WriteLine($"Choose how many {type} do you want (min {min}):");
                string input = Console.ReadLine();
                if (int.TryParse(input, out amount) && (amount >= min))
                    return amount;

            } while (true);
        }

        public AttackType ChooseAttackType(Character controlledCharacter)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"It's time for {controlledCharacter.FullyQualifiedName} to act. Please choose his action between [B]ase attack and [S]pecial action:");
            Console.ResetColor();

            while (true)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.B: return AttackType.BaseAttack;
                    case ConsoleKey.S: return AttackType.SpecialAction;
                }

                Console.WriteLine("Invalid option. Please digit 'B' for Base attack and 'S' for Special action");
            }
        }
    }
}
