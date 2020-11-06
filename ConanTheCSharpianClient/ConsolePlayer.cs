

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

        public int HowManyAllies()
        {
            string input;
            int alliesNumber;
            do
            {
                Console.WriteLine("Choose how many Allies do you want to play with: ");
                input = Console.ReadLine();
                try
                {
                    alliesNumber = Convert.ToInt32(input);
                }catch(Exception e)
                {
                    alliesNumber = 0;
                }
                
            }while(alliesNumber < 1);
            return alliesNumber;
        }

        public int HowManyMonster()
        {
            string input;
            int monstersNumber;
            do
            {
                Console.WriteLine("Choose how many Monsters do you want to play against: ");
                input = Console.ReadLine();
                try
                {
                    monstersNumber = Convert.ToInt32(input);
                }catch(Exception e)
                {
                    monstersNumber = 0;
                }
                
            }while(monstersNumber < 1);
            return monstersNumber;
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
