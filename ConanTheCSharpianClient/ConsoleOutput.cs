

using ConanTheCSharpian.Core;
using System;

namespace ConanTheCSharpian.Client
{
    public class ConsoleOutput : IMessageHandler
    {
        private bool _alternateColor;

        public void DisplayMessage(string message, bool pause)
        {
            Console.ForegroundColor = _alternateColor ? ConsoleColor.DarkGray : ConsoleColor.Gray;

            Console.WriteLine(message);
            if (pause)
                Console.ReadKey(true);

            _alternateColor = !_alternateColor;
        }
    }
}
