

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

        public int ChooseHowManyAllies(int minimum)
        {
            return AmountOfFighters(0, "How many allies do you want to play with?");
        }

        public int ChooseHowManyMonsters(int minimum)
        {
            return AmountOfFighters(1, "How many monsters do you want to play against?");
        }

        public int AmountOfFighters(int minimum, string question)
        {
            int amount = -1;
            do
            {
                Console.WriteLine(question);
                try
                {
                    amount = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Insert whole numbers only");
                    continue;
                }
                if (amount < minimum)
                    Console.WriteLine($"The number can't be less than {minimum}");
            } while (amount < minimum);

            return amount;
        }

        public void ChooseAttackType(Character controlledCharacter)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"It's time for {controlledCharacter.FullyQualifiedName} to act. Please choose his action between [B]ase attack and [S]pecial action:");
            Console.ResetColor();

            while (true)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.B:
                        controlledCharacter.PerformBaseAttack();
                        return;

                    case ConsoleKey.S:
                        controlledCharacter.PerformSpecialAction();
                        return;
                }

                Console.WriteLine("Invalid option. Please digit 'B' for Base attack and 'S' for Special action");
            }
        }
    }
}
