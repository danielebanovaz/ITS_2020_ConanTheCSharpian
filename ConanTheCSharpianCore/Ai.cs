

using System;

namespace ConanTheCSharpian.Core
{
    public class Ai : ICharacterController
    {
        private Random _random = new Random();

        public AttackType ChooseAttackType(Character controlledCharacter)
        {
            int randomDiceRoll = _random.Next(1, 10);

            if (randomDiceRoll <= 3)
                return AttackType.BaseAttack;
            else
                return AttackType.SpecialAction;
        }
    }
}
