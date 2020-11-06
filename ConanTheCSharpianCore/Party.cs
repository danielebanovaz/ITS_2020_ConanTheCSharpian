

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public abstract class Party<TCharacter> : IParty
        where TCharacter : Character
    {
        protected List<TCharacter> Characters = new List<TCharacter>();

        public Party(CharacterType userControlledCharacterType,Battlefield battlefield, ICharacterController characterController, string number_allies_monster)
        {
            CreateCharacterInstances(number_allies_monster,userControlledCharacterType);

            foreach (Character characterToInitialize in Characters)
                characterToInitialize.Initialize(battlefield, characterController);
        }

        protected abstract void CreateCharacterInstances(string number_allies_monster, CharacterType userControlledCharacterType);

        public bool IsEverybodyDead()
        {
            foreach (Character character in Characters)
                if (!character.IsDead)
                    return false;

            return true;
        }

        public List<Character> GetAliveCharacters()
        {
            List<Character> aliveCharacters = new List<Character>();

            foreach(Character character in Characters)
                if (!character.IsDead)
                    aliveCharacters.Add(character);

            return aliveCharacters;
        }

        internal TCharacter this[CharacterType characterType]
        {
            get
            {
                foreach (TCharacter character in Characters)
                    if (character.Category == characterType)
                        return character;

                throw new NotSupportedException($"{characterType} is not related to this party");
            }
        }
    }
}
