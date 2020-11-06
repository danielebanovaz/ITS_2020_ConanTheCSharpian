

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        private static Random _random = new Random();
        public HeroParty(CharacterType userControlledCharacterType,Battlefield battlefield, ICharacterController characterController, string numberallies)
            : base(userControlledCharacterType,battlefield, characterController, numberallies)
        {
           
        }
        
        protected override void CreateCharacterInstances(string numberallies, CharacterType userControlledCharacterType)
        {
            //   String[] allies = { "Barbarian", "Ranger", "Mage" };
            int number = Int32.Parse(numberallies);
            
            if (userControlledCharacterType.Equals((CharacterType.Barbarian))) //compare the type of character you choose with the ones you have
            {
                Characters.Add(new Barbarian());
            }else if(userControlledCharacterType.Equals((CharacterType.Ranger)))
            {
                Characters.Add(new Ranger());
            }
            else if (userControlledCharacterType.Equals((CharacterType.Mage)))
            {
                Characters.Add(new Mage());
            }
            for (int i = 0; i < number; i++)
            {
                int num = _random.Next(3);
                // string monsterrandom = monster[num];
                if (num == 0)
                {
                    Characters.Add(new Barbarian());
                }
                else if (num == 1)
                {
                    Characters.Add(new Ranger());
                }
                else
                {
                    Characters.Add(new Mage());
                }


            }
        }

    }
}
