

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int monsters)
               : base(battlefield, characterController, monsters)
        { }

        protected override void CreateCharacterInstances(int monsters)
        {
            for (int i = 1; i <= monsters; i++)
            {
                switch (i)
                {
                    case 1:
                        Characters.Add(new Goblin());
                        break;
                    case 2:
                        Characters.Add(new Troll());
                        break;
                    case 3:
                        Characters.Add(new Warlock());
                        break;
                    case 4:
                        Characters.Add(new Necromancer());
                        break;
                    default:
                        Characters.Add(new Goblin());
                        break;
                }
            }
        }

        protected void CreateNewCharacter(Character monster) //non sono riuscito ad implementarlo - non ho abbastanza tempo-
        {
            Characters.Add(new Goblin());
        }
    }
}
