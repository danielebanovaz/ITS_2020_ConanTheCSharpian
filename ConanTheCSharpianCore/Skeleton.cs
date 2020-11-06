

namespace ConanTheCSharpian.Core
{
    public class Skeleton : Monster
    {
        private float _decayingLife = 4;

        public Skeleton()
        {
            Damage = 14;
            MaxHealth = 20;
            Accuracy = 0.6f;
        }

        protected override void PerformSpecialAction()
        {
            Battlefield.DisplayMessage($"{FullyQualifiedName} just suffered from a call of the Death, losing {_decayingLife}hp.");
            CurrentHealth -= _decayingLife;
        }
    }
}
