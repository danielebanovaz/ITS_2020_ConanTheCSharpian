namespace ConanTheCSharpian.Core
{
    public class Necromancer : Monster
    {
        public Necromancer()
        {
            Name = "Seitan";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.5f;
            MaxMana = 80;
        }

        public override void PerformSpecialAction()
        {
            int  ManaCost = 50;
            if (_currentMana - ManaCost >= 0)
            {
                _currentMana -= ManaCost;

                //TODO implement spawn mechanic -add mana regen-
            }
            else
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} doesn't have enough mana to use the special attack");
                //TODO riprova a scegliere invece di saltare il turno
            }
        }
    }
}
