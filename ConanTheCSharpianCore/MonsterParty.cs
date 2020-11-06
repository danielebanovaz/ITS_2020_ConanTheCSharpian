

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        private Random _random = new Random();
        public MonsterParty(Battlefield battlefield, ICharacterController characterController)
               : base(battlefield, characterController)
        { }

        protected override void CreateCharacterInstances()
        {
            Characters.Add(new Goblin());
            Characters.Add(new Troll());
            Characters.Add(new Warlock());
             _random.Next(Characters.ToString().Length);

        }
    }
}
