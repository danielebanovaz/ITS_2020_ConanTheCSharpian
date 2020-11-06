

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public interface IParty
    {

        bool IsEverybodyDead();

        List<Character> GetAliveCharacters();
        void CreateCharacterInstances();
    }
}
