

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public abstract class Party<TCharacter> : IParty
        where TCharacter : Character
    {
        protected List<TCharacter> Characters = new List<TCharacter>();
        protected Random Rand = new Random();

        public Party(Battlefield battlefield, ICharacterController characterController, int numOfMembers)
        {
            CreateCharacterInstances(numOfMembers);

            foreach (Character characterToInitialize in Characters)
                characterToInitialize.Initialize(battlefield, characterController);
        }

        protected abstract void CreateCharacterInstances(int numOfMembers);

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
