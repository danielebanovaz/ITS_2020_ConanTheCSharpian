

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        public HeroParty(Battlefield battlefield, ICharacterController characterController, int allies)
            : base (battlefield, characterController, allies)
        { }

        protected override void CreateCharacterInstances(int allies)
        {
            for(int i=1; i<=allies; i++)
            { 
               switch (i)
                {
                    case 1: Characters.Add(new Barbarian());
                        break;
                    case 2: Characters.Add(new Ranger());
                        break;
                    case 3: Characters.Add(new Mage());
                        break;
                    case 4: Characters.Add(new Paladin());
                        break;
                    default: Characters.Add(new Barbarian());
                        break;
                }                
            }
            
            
        }
    }
}
