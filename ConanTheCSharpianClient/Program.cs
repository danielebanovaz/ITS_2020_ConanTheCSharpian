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

            IMessageHandler consoleMessageHandler = new ConsoleOutput();
            ConsolePlayer player = new ConsolePlayer();
           
            while (true)
            {
                DisplayGameTitle();

                CharacterType type = player.ChooseHeroCategory();
                string name = player.ChooseHeroName();
                int alliesNumber = player.AlliesNumber();
                int monster = player.MonstersNumber();
                

                Battlefield battlefield = new Battlefield(consoleMessageHandler);
                battlefield.RunBattle(type, name, player);


                Console.WriteLine("Do you want to play again? [Y/N]");
                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    return;

                Console.Clear();
            }
        }

        private static void DisplayGameTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"                     ___
       .----.      __) `\      ___ ___  _ __   __ _ _ __  
       | == |     < __=- |    / __/ _ \| '_ \ / _` | '_ \ 
    ___| :: |___   \\ `)/    | (_| (_) | | | | (_| | | | | 
    \  `----'  /\  (\) (      \___\___/|_| |_|\__,_|_| |_|        
     \   `.   /( \/ /\\
     |    :   | \  /  \\            the CSharpian
     \   _._  /  `""   <_>
      xxx(o)xx
            ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Conan the CSharpian game!");
            Console.ResetColor();
        }
    }
}
