

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        Random random = new Random();
        public MonsterParty(Battlefield battlefield, ICharacterController characterController)
               : base(battlefield, characterController)
        { }

        protected  void CreateCharacterInstances(string num_enemys)
        {
            int _random;
            int i = 0;
            do
            {
                _random = random.Next(1, 3);

                switch (_random)
                {
                    case 1:
                        AddTroll();
                        break;
                    case 2:
                        AddGoblin();
                        break;
                    case 3:
                        AddWarlock();
                        break;
                }
                i++;
            } while (i < Convert.ToInt32(num_enemys));


        }


        private void AddTroll()
        {
            Characters.Add(new Troll());
        }

        private void AddGoblin()
        {
            Characters.Add(new Goblin());
        }

        private void AddWarlock()
        {
            Characters.Add(new Warlock());
        }

    }
}
