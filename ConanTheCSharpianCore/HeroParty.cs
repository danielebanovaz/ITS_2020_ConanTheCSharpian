

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private int allies=0;
        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController)
        {
           
           
        }

        protected override void CreateCharacterInstances()
        {
            /*+   var rand = new Random();

               for (int i=0; i<allies; i++)
               {
                   int r = rand.Next(1, 3);
                   switch(r)
                   {
                       case 1:
                           Characters.Add(new Barbarian());
                           break;
                       case 2:
                           Characters.Add(new Ranger());
                           break;
                       case 3:
                           Characters.Add(new Mage());
                           break;
                       default:
                           break;
                   }
               }*/
            Characters.Add(new Barbarian());
            Characters.Add(new Ranger());
            Characters.Add(new Mage());
        }
    }
}