

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        private static Random _random = new Random();
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int numberOfHeroPartyMembers)
               : base(battlefield, characterController, numberOfHeroPartyMembers)
        { }

        protected override void CreateCharacterInstances()
        {
            //Characters.Add(new Goblin());
            //Characters.Add(new Troll());
            //Characters.Add(new Warlock());
            int randomIndex = _random.Next(0, Enum.GetValues(typeof(CharacterType)).Length);
            switch (randomIndex)
            {
                case 1:
                    Characters.Add(new Troll());
                    break;
                case 2:
                    Characters.Add(new Goblin());
                    break;
                case 3:
                    Characters.Add(new Warlock());
                    break;
            }
        }
        public enum CharacterType
        {
            Troll,
            Goblin,
            Warlock,
            Negromancer,
            Skeleton
        }
    }
}
