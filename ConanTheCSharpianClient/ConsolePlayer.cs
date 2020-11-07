

using ConanTheCSharpian.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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

        public int AlliesNumber()
        {
            int number = 0;
            do
            {
                Console.WriteLine("how many allies you want to play with:");
           // number = int.Parse(Console.ReadLine());
            
                number = int.Parse(Console.ReadLine());
                if(number < 0)
                Console.WriteLine("il minimo è 0.Please choose another number more than or equals a 0");
               

            } while (number < 0);
            
            return number;
        }
        public int MonstersNumber()
        {
            int number = 0;
            do
            {
                Console.WriteLine("how many monsters you want to play against:");
                number = int.Parse(Console.ReadLine());
                if(number < 1)
                Console.WriteLine("il minimo è 1.Please choose another number more than or equals a 1");
                
            } while (number < 1);
            return number;
        }
    }
}
