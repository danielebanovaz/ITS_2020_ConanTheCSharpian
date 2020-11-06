
using System.Collections.Generic;
namespace ConanTheCSharpian.Core
{
    public class Paladin : Hero
    {
        public Paladin()
        {
            Name = "Vindictus";
            Damage = 25;
            MaxHealth = 100;
            Accuracy = 0.7f;
            MaxMana = 50;
        }

        public override void PerformSpecialAction()
        {
            int ManaCost = 30;
            if (_currentMana - ManaCost >= 0)
            {
                _currentMana -= ManaCost;
                //TODO implement ally buff mechanic - add mana regen-
            }
            else
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} doesn't have enough mana to use the special attack");
                //TODO riprova a scegliere invece di saltare il turno
            }
        }
    }
}
