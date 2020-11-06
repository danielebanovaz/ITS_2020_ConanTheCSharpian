

namespace ConanTheCSharpian.Core
{
    public class Troll : Monster
    {
        public Troll()
        {
            Damage = 50;
            MaxHealth = 160;
            Accuracy = 0.3f;
        }

        public override void PerformSpecialAction()
        {
            Attack(GetRandomCharacter(), Damage * 3, Accuracy / 3, "Special attack: ");
        }
    }
}
