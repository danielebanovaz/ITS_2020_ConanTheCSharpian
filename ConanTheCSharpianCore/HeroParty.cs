

using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private Random _random = new Random();
        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController)
        { }

        protected override void CreateCharacterInstances()
        {
         
            Characters.Add(new Barbarian());
            Characters.Add(new Ranger());
            Characters.Add(new Mage());
           int m = _random.Next(0,Characters.ToString().Length);
           
        }
        

    }
}
