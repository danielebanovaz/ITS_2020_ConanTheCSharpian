

using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private Random _random = new Random();
        public HeroParty(Battlefield battlefield, ICharacterController characterController, int alliesNumbers)
            : base(battlefield, characterController, alliesNumbers)
        { }

        protected override void CreateCharacterInstances(int alliesNumbers)
        {
            for (int i = 0; i <= alliesNumbers; i++)
            {
                Characters.Add(new Barbarian());
                Characters.Add(new Ranger());
                Characters.Add(new Mage());
                int m = _random.Next(0, Characters.ToString().Length);
            }

        }


    }
}
