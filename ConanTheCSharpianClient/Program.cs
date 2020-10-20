using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConanTheCSharpian.Core;

namespace ConanTheCSharpian.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Conan the CSharpian!");

            IMessageHandler consoleMessageHandler = new ConsoleOutput();
            ConsolePlayer player = new ConsolePlayer();

            while (true)
            {
                CharacterType type = player.ChooseHeroCategory();
                string name = player.ChooseHeroName();

                Battlefield battlefield = new Battlefield(consoleMessageHandler);
                battlefield.RunBattle(type, name, player);

                Console.WriteLine("Do you want to play again? [Y/N]");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                    return;
            }
        }
    }
}
