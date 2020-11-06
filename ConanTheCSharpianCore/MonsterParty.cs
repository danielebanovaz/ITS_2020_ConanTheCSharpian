

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {

        protected override List<CharacterType> AllowedCharacterTypes => new List<CharacterType>() {
            CharacterType.Troll, CharacterType.Goblin, CharacterType.Warlock, CharacterType.Necromancer
        };


        public MonsterParty(Battlefield battlefield, int monstersAmount, ICharacterController characterController)
               : base(battlefield, characterController, monstersAmount)
        { }
    }
}
