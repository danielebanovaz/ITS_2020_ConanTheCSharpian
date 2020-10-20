

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Battlefield
    {
        private HeroParty _heroes = new HeroParty();
        private MonsterParty _monsters = new MonsterParty();

        public bool IsGameFinished
        {
            get
            {
                return _heroes.IsEverybodyDead() || _monsters.IsEverybodyDead();
            }
        }

        public void RunBattle()
        {
            do
            {
                if (LetPartyAct(_heroes))
                    break;

                if (LetPartyAct(_monsters))
                    break;

            } while (!IsGameFinished);
        }

        private bool LetPartyAct(IParty party)
        {
            foreach (Character character in party.GetAliveCharacters())
            {
                character.Act();

                if (IsGameFinished)
                    return true;
            }

            return false;
        }

        public void UseNextCharacter()
        {
            // TODO: implement that
            throw new System.NotImplementedException();
        }

        internal List<Character> GetValidTargets(Character callingCharacter, TargetType targetsType)
        {
            List<Character> validTargets = new List<Character>();

            IParty allies;
            IParty opponents;

            if (callingCharacter is Hero)
            {
                allies = _heroes;
                opponents = _monsters;
            }
            else
            {
                allies = _monsters;
                opponents = _heroes;
            }


            switch (targetsType)
            {
                case TargetType.Opponents:
                    validTargets.AddRange(opponents.GetAliveCharacters());
                    break;
                case TargetType.Allies:
                    validTargets.AddRange(allies.GetAliveCharacters());
                    break;
                case TargetType.All:
                    validTargets.AddRange(allies.GetAliveCharacters());
                    validTargets.AddRange(opponents.GetAliveCharacters());
                    break;
            }

            return validTargets;
        }
    }

    public enum TargetType { Allies, Opponents, All }
}
