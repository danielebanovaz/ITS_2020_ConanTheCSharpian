

using ConanTheCSharpian.Core;
using System;

namespace ConanTheCSharpian.Client
{
    public class ConsoleOutput : IMessageHandler
    {
        public void DisplayMessage(string message, bool pause)
        {
            Console.WriteLine(message);
            if (pause)
                Console.ReadLine();
        }
    }
}
