

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : IParty
    {
        private Barbarian _barbarian = new Barbarian();
        private Ranger _ranger = new Ranger();
        private Mage _mage = new Mage();

        public HeroParty(Battlefield battlefield, ICharacterController characterController)
        {
            _barbarian.Initialize(battlefield, characterController);
            _ranger.Initialize(battlefield, characterController);
            _mage.Initialize(battlefield, characterController);
        }

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

        internal Character GetCharacter(CharacterType characterType)
        {
            switch (characterType)
            {
                case CharacterType.Barbarian: return _barbarian;
                case CharacterType.Ranger: return _ranger;
                case CharacterType.Mage: return _mage;
                default: throw new NotSupportedException($"{characterType} is not related to this party");
            }
        }
    }
}
