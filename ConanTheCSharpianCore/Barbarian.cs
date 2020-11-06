

namespace ConanTheCSharpian.Core
{
    public class Barbarian : Hero
    {
        public Barbarian()
        {
            Damage = 30;
            MaxHealth = 120;
            Accuracy = 0.6f;
        }

        protected override void PerformSpecialAction()
        {
            Attack(GetRandomCharacter(), Damage * 2, Accuracy / 2, "Special attack: ");
        }
    }
}
