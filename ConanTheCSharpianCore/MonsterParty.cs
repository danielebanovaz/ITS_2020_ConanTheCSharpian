

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        private static Random _random = new Random();
        public MonsterParty(CharacterType userControlledCharacterType,Battlefield battlefield, ICharacterController characterController, string numbermonster)
               : base(userControlledCharacterType,battlefield, characterController, numbermonster)
        { }

        protected override void CreateCharacterInstances(string numbermonster, CharacterType userControlledCharacterType)
        {
          //  String[] monster = { "Goblin", "Troll", "Warlock" };
            int number=Int32.Parse(numbermonster);
            for (int i = 0; i < number; i++)
            {
               int num = _random.Next(3);
                // string monsterrandom = monster[num];
                if (num == 0)
                {
                    Characters.Add(new Goblin());
                }
                else if(num==1)
                {
                    Characters.Add(new Troll());
                }
                else
                {
                    Characters.Add(new Warlock());
                }
               
            }
            
            
           
        }
    }
}
