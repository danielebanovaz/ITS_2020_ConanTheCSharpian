

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        public HeroParty(Battlefield battlefield, ICharacterController characterController, int numOfMembers, CharacterType userControlledCharacterType)
            : base (battlefield, characterController, numOfMembers)
        {
            HeroType category = (HeroType)Enum.Parse(typeof(HeroType), userControlledCharacterType.ToString());
            CharacterInstance(category);
        }

        protected override void CreateCharacterInstances(int numOfAllies)
        {
            for (int i = 0; i < numOfAllies; i++)
            {
                HeroType category = (HeroType)Rand.Next(Enum.GetNames(typeof(HeroType)).Length);
                CharacterInstance(category);
            }
        }

        private void CharacterInstance(HeroType category)
        {
            switch (category)
            {
                case HeroType.Barbarian:
                    Characters.Add(new Barbarian());
                    break;
                case HeroType.Ranger:
                    Characters.Add(new Ranger());
                    break;
                case HeroType.Mage:
                    Characters.Add(new Mage());
                    break;
            }
        }

        public Character GetPlayerCharacter()
        {
            Hero playerCharacter = Characters[Characters.Count - 1];
            RandomizeOrder(playerCharacter);
            return playerCharacter;
        }

        private void RandomizeOrder(Hero playerCharacter)
        {
            Characters.Remove(playerCharacter);
            Characters.Insert(Rand.Next(Characters.Count), playerCharacter);
        }
    }

    public enum HeroType
    {
        Barbarian,
        Ranger,
        Mage
    }
}
