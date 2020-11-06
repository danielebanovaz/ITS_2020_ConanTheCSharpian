

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
 
        public HeroParty(Battlefield battlefield, ICharacterController characterController,int numberOfHeroes)
            : base (battlefield, characterController,numberOfHeroes)
        {     
        }

        protected override void CreateCharacterInstances(int numberOfHeroes)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfHeroes+1; i++)
            {
                int choosenHero = random.Next(1,5);


                switch (choosenHero)
                {
                    case (1): Characters.Add(new Barbarian()); break;
                    case (2): Characters.Add(new Ranger()); break;
                    case (3): Characters.Add(new Mage()); break;
                    case (4): Characters.Add(new Paladin()); break;
                    default: throw new NotImplementedException();
                }

            }
        }
    }
}
