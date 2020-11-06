

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public abstract class Party<TCharacter> : IParty
        where TCharacter : Character
    {
        protected List<TCharacter> Characters = new List<TCharacter>();
        protected abstract List<CharacterType> AllowedCharacterTypes { get; }

        public Party(Battlefield battlefield, ICharacterController characterController, int amountToCreate)
        {
            for (int i = 0; i < amountToCreate; i++)
            {
                CharacterType randomType = Helpers.GetRandomElement(AllowedCharacterTypes);
                CreateNewCharacter(randomType, characterController, battlefield);
            }
        }

        public void CreateNewCharacter(CharacterType characterType, ICharacterController controller, Battlefield battlefield, string customName = null)
        {
            Character newCharacter;
            switch (characterType)
            {
                case CharacterType.Barbarian: newCharacter = new Barbarian(); break;
                case CharacterType.Ranger: newCharacter = new Ranger(); break;
                case CharacterType.Mage: newCharacter = new Mage(); break;
                case CharacterType.Paladin: newCharacter = new Paladin(); break;
                case CharacterType.Troll: newCharacter = new Troll(); break;
                case CharacterType.Goblin: newCharacter = new Goblin(); break;
                case CharacterType.Warlock: newCharacter = new Warlock(); break;
                case CharacterType.Necromancer: newCharacter = new Necromancer(); break;
                case CharacterType.Skeleton: newCharacter = new Skeleton(); break;
                default: throw new NotSupportedException();
            }

            newCharacter.Initialize(battlefield, controller, customName);
            Characters.Insert(0, (TCharacter)newCharacter);
        }

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
