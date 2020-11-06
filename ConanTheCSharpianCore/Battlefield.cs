

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class Battlefield : IMessageHandler
    {
        public HeroParty Heroes { get; private set; }
        public MonsterParty Monsters { get; private set; }
        private IMessageHandler _messageHandler;
        public ICharacterController AiController { get; private set; }

        public bool IsGameFinished
        {
            get
            {
                return Heroes.IsEverybodyDead() || Monsters.IsEverybodyDead();
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

        public void RunBattle(CharacterType userControlledCharacterType, string userControlledCharacterName, ICharacterController playerController, int alliesAmount, int monstersAmount)
        {
            AiController = new Ai();
            Heroes = new HeroParty(this, userControlledCharacterType, userControlledCharacterName, playerController, alliesAmount, AiController);
            Monsters = new MonsterParty(this, monstersAmount, AiController);

            Character userControlledCharacter = Heroes[userControlledCharacterType];
            userControlledCharacter.Initialize(this, playerController, userControlledCharacterName);

            int currentTurn = 1;
            do
            {
                DisplayMessage($"\n\tTurn {currentTurn} is about to start:", true);

                if (LetPartyAct(Heroes))
                    break;

                if (LetPartyAct(Monsters))
                    break;

                currentTurn++;

            } while (!IsGameFinished);

            if (Heroes.IsEverybodyDead())
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
                allies = Heroes;
                opponents = Monsters;
            }
            else
            {
                allies = Monsters;
                opponents = Heroes;
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
