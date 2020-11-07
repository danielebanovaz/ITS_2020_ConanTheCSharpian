

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private static Random _random = new Random();
        //ConsolePlayer consolePlayer = new ConsolePlayer();
        public HeroParty(Battlefield battlefield, ICharacterController characterController)
            : base (battlefield, characterController)
        { }
        
        protected override void CreateCharacterInstances()
        {
            /*for (int i = 0; i < consolePlayer.numberOfAllies; i++)
            {
                int randomnum = _random.Next(0, 4);
                if (randomnum == 0)*/
                    Characters.Add(new Barbarian());
                //else if (randomnum == 1)
                    Characters.Add(new Ranger());
                //else if (randomnum == 2)
                    Characters.Add(new Mage());
                //else if (randomnum == 3)
                    Characters.Add(new Paladin());
            //}
        }
    }
}

