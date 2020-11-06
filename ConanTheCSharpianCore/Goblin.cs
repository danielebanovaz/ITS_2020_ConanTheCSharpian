

namespace ConanTheCSharpian.Core
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            Damage = 20;
            MaxHealth = 85;
            Accuracy = 0.8f;
        }

        protected override void PerformSpecialAction()
        {
            Attack(GetRandomCharacter(), Damage * 0.75f, Accuracy * 2, "Special attack: ");
        }
    }
}
