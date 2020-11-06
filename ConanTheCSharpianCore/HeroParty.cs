

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        public int numbersOfAllies;

        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController)
        {
            
        }


        protected override void CreateCharacterInstances()
        {
            Characters.Add(new Barbarian());
            Characters.Add(new Ranger());
            Characters.Add(new Mage());

            int cont = 0;

            do
            {
                if(cont < numbersOfAllies)
                {
                    Characters.Add(new Barbarian());
                    cont++;
                }
            } while (cont < numbersOfAllies);
        }
    }
}
