

using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : IParty
    {
        private Barbarian _barbarian = new Barbarian();
        private Ranger _ranger = new Ranger();
        private Mage _mage = new Mage();

        public bool IsEverybodyDead()
        {
            return _barbarian.IsDead && _ranger.IsDead && _mage.IsDead;
        }

        public List<Character> GetAliveCharacters()
        {
            List<Character> aliveCharacters = new List<Character>();
            if (!_barbarian.IsDead)
                aliveCharacters.Add(_barbarian);

            if (!_ranger.IsDead)
                aliveCharacters.Add(_ranger);

            if (!_mage.IsDead)
                aliveCharacters.Add(_mage);

            return aliveCharacters;
        }
    }
}
