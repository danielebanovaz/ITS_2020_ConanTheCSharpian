

using ConanTheCSharpian.Core;
using System;

namespace ConanTheCSharpian.Client
{
    public class ConsoleOutput : IMessageHandler
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
