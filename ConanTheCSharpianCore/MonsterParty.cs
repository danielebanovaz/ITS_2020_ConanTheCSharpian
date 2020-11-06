

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        private Random _random = new Random();
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int monsterNumber)
               : base(battlefield, characterController, monsterNumber)
        { }

        protected override void CreateCharacterInstances(int monstersNumber)
        {
            for (int i = 0; i <= monstersNumber; i++)
            {
                Characters.Add(new Goblin());
                Characters.Add(new Troll());
                Characters.Add(new Warlock());
                _random.Next(0, Characters.ToString().Length);
            }
        }
    }
}
