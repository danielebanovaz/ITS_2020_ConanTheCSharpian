

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

        public int ChooseNumberOfAllies()
        {
            int numberOfAllies;
            do
            {
                Console.WriteLine("Choose the number of your allies: ");
                numberOfAllies = Convert.ToInt32(Console.ReadLine());//manca un try catch per controllare se l'utente non scrive un numero o un numero sbagliato
            } while (numberOfAllies < 0);
            return numberOfAllies;
        }

        public int ChooseNumberOfMonsters()
        {
            int numberOfMonsters;
            do
            {
                Console.WriteLine("Choose the number of monsters: ");
                numberOfMonsters = Convert.ToInt32(Console.ReadLine());//manca un try catch per controllare se l'utente non scrive un numero o un numero sbagliato
            } while (numberOfMonsters < 0);
            return numberOfMonsters;
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
