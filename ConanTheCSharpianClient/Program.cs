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

            while (true)
            {
                Battlefield battlefield = new Battlefield(consoleMessageHandler);
                battlefield.RunBattle();

                Console.WriteLine("Do you want to play again? [Y/N]");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                    return;
            }
        }
    }
}
