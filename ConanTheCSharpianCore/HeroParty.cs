

using System;
using System.Collections.Generic;


namespace ConanTheCSharpian.Core
{    
    public class HeroParty : Party<Hero>

    {
        Random random = new Random();

        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController )
        {        }

        protected void CreateCharacterInstances(string num_allies)
        {
            int _random;
            int i = 0;
            do
            {
                _random = random.Next(1, 3);

                switch (_random)
                { 

                    case 1:
                        AddBarbarian();
                        break;
                    case 2:
                        AddRanger();
                        break;
                    case 3:
                        AddMage();
                        break;
                }
                i++;
            } while (i < Convert.ToInt32(num_allies));
          
        }

 
        private void AddBarbarian()
        {
            Characters.Add(new Barbarian());
        }

        private void AddRanger()
        {
            Characters.Add(new Ranger());
        }

        private void AddMage()
        {
            Characters.Add(new Mage());
        }

    }
}
