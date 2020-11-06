

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int numerOfMonster)
               : base(battlefield, characterController, numerOfMonster)
        { }

        protected override void CreateCharacterInstances(int numerOfMonster)
        {
            Random random = new Random();
            int choosenMonster;
            for (int i = 0; i < numerOfMonster; i++)
            {
               choosenMonster = random.Next(1, 4);
                 switch (choosenMonster)
                {
                    case (1): Characters.Add(new Troll()); break;
                    case (2): Characters.Add(new Goblin()); break;
                    case (3): Characters.Add(new Warlock()); break;
                    default: throw new NotImplementedException();
                }

            }
        }
    }
}
