

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        private int monsters = 0;
        public MonsterParty(Battlefield battlefield, ICharacterController characterController)
               : base(battlefield, characterController)
        {
           
        }

        protected override void CreateCharacterInstances()
        {
            /*  var rand = new Random();
              for (int i = 0; i < monsters; i++)
              {
                  int r = rand.Next(1, 3);
                  switch (r)
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
                      default:
                          break;
                  }
              }*/
            Characters.Add(new Goblin());
            Characters.Add(new Troll());
            Characters.Add(new Warlock());
        }
    }
}
