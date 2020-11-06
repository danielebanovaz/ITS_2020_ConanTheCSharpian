

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController)
        { }
        
        protected override void CreateCharacterInstances()
        {
            
            {
                Characters.Add(new Barbarian());
                Characters.Add(new Ranger());
                Characters.Add(new Mage());
            }
            
        }
    }
}
