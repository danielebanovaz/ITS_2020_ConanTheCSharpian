

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : IParty
    {
        private Goblin _goblin = new Goblin();
        private Troll _troll = new Troll();
        private Warlock _warlock = new Warlock();

        public MonsterParty(Battlefield battlefield, ICharacterController characterController)
        {
            _goblin.Initialize(battlefield, characterController);
            _troll.Initialize(battlefield, characterController);
            _warlock.Initialize(battlefield, characterController);
        }

        public bool IsEverybodyDead()
        {
            return _goblin.IsDead && _troll.IsDead && _warlock.IsDead;
        }

        public List<Character> GetAliveCharacters()
        {
            List<Character> aliveCharacters = new List<Character>();
            if (!_goblin.IsDead)
                aliveCharacters.Add(_goblin);

            if (!_troll.IsDead)
                aliveCharacters.Add(_troll);

            if (!_warlock.IsDead)
                aliveCharacters.Add(_warlock);

            return aliveCharacters;
        }
    }
}
