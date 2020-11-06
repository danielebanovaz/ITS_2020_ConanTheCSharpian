

using System;

namespace ConanTheCSharpian.Core
{
    public class Ai : ICharacterController
    {
        private Random _random = new Random();

        

        public void ChooseAttackType(Character controlledCharacter)
        {
            int randomDiceRoll = _random.Next(1, 10);

            if (randomDiceRoll <= 3)
                controlledCharacter.PerformSpecialAction();
            else
                controlledCharacter.PerformBaseAttack();
        }

       
    }
}
