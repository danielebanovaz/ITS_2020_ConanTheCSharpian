

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        List<Monster> characters = new List<Monster>();
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int characterAmount)
               : base(battlefield, characterController, characterAmount)
        { }

        protected override void CreateCharacterInstances(int characterAmount)
        {
            for (int i = 0; i < characterAmount; i++)
            {
                Characters.Add(SetCharacter(characterAmount));
                characterAmount = -1;
            }
            
            //Characters.AddRange(Enumerable.Range(0, characterAmount).Select(x => new Goblin()));
            //Characters.AddRange(Enumerable.Range(0, characterAmount).Select(x => new Troll()));
            //Characters.AddRange(Enumerable.Range(0, characterAmount).Select(x => new Warlock()));
        }

        protected override Monster SetCharacter(int characterFlag)
        {
            Random _random = new Random();
            int _index;
            characters.Add(new Troll());
            characters.Add(new Warlock());
            characters.Add(new Goblin());
           
            if (characterFlag >= Characters.Count)
            {
                _index = _random.Next(0, characters.Count - 1);
                return characters[_index];
            }

            return characters[characterFlag];
        }
    }
}
