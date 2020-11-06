﻿

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Battlefield : IMessageHandler
    {
        private HeroParty _heroes;
        private MonsterParty _monsters;
        private IMessageHandler _messageHandler;
        private ICharacterController _ai = new Ai();

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

        public void DisplayMessage(string message, bool pause = false)
        {
            _messageHandler.DisplayMessage(message, pause);
        }

        public void RunBattle(Character.CharacterType userControlledCharacterType, string userControlledCharacterName, ICharacterController playerController)
        {
            _heroes = new HeroParty(this, _ai);
            _monsters = new MonsterParty(this, _ai);

            Character userControlledCharacter = _heroes[userControlledCharacterType];
            userControlledCharacter.Initialize(this, playerController, userControlledCharacterName);

            int currentTurn = 1;
            do
            {
                DisplayMessage($"\n\tTurn {currentTurn} is about to start:", true);

                if (LetPartyAct(_heroes))
                    break;

                if (LetPartyAct(_monsters))
                    break;

                currentTurn++;

            } while (!IsGameFinished);

            if (_heroes.IsEverybodyDead())
                DisplayMessage("\n\tOh noes! The monsters won.\n");
            else
                DisplayMessage("\n\tHurray! Your heroes won this battle!\n");
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
