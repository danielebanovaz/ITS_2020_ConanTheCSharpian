

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private static Random _random = new Random();
        public HeroParty(Battlefield battlefield, ICharacterController characterController, int numberOfHeroPartyMembers)
            : base (battlefield, characterController, numberOfHeroPartyMembers)
        { }

        protected override void CreateCharacterInstances()
        {
            //Characters.Add(new Barbarian());
            //Characters.Add(new Ranger());
            //Characters.Add(new Mage());
            int randomIndex = _random.Next(0, Enum.GetValues( typeof(CharacterType)).Length);
            switch (randomIndex)
            {
                case 1: Characters.Add(new Barbarian());
                    break;
                case 2: Characters.Add(new Ranger());
                    break;
                case 3: Characters.Add(new Mage());
                    break;
                case 4:
                    Characters.Add(new Paladin());
                    break;
            }
        }
        public enum CharacterType
        {
            Barbarian,
            Ranger,
            Mage,
            Paladin
        }
    }
}
