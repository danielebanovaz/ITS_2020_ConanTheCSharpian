

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Battlefield : IMessageHandler
    {
        private HeroParty _heroes = new HeroParty();
        private MonsterParty _monsters = new MonsterParty();
        private IMessageHandler _messageHandler;

        public bool IsGameFinished
        {
            get
            {
                return _heroes.IsEverybodyDead() || _monsters.IsEverybodyDead();
            }
        }

        public Battlefield(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void DisplayMessage(string message)
        {
            _messageHandler.DisplayMessage(message);
        }

        public void RunBattle()
        {
            int currentTurn = 1;
            do
            {
                DisplayMessage($"Turn {currentTurn} is about to start:");

                if (LetPartyAct(_heroes))
                    break;

                if (LetPartyAct(_monsters))
                    break;

            } while (!IsGameFinished);

            if (_heroes.IsEverybodyDead())
                DisplayMessage("Oh noes! The monsters won.");
            else
                DisplayMessage("Hurray! Your heroes won this battle!");
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
