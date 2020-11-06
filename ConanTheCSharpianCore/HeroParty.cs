

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        protected override List<CharacterType> AllowedCharacterTypes => new List<CharacterType>() {
            CharacterType.Barbarian, CharacterType.Ranger, CharacterType.Mage, CharacterType.Paladin
        };

        public HeroParty(Battlefield battlefield, CharacterType userControlledCharacterType, string userControlledCharacterName, ICharacterController playerController, int alliesAmount, ICharacterController aiController)
            : base (battlefield, aiController, alliesAmount)
        {
            CreateNewCharacter(userControlledCharacterType, playerController, battlefield, userControlledCharacterName);
        }
    }
}
