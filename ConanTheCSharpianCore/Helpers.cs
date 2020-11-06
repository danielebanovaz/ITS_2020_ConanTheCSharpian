

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Helpers
    {
        private static Random _randomGenerator = new Random();

        public static T GetRandomElement<T>(List<T> collection)
        {
            int randomIndex = _randomGenerator.Next(0, collection.Count);
            return collection[randomIndex];
        }
    }
}
