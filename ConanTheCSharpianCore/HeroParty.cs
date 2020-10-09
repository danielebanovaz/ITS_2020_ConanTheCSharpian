

namespace ConanTheCSharpian.Core
{
    public class HeroParty : IParty
    {
        private Barbarian _barbarian = new Barbarian();
        private Ranger _ranger = new Ranger();
        private Mage _mage = new Mage();

        public bool IsEverybodyDead()
        {
            return _barbarian.IsDead() && _ranger.IsDead() && _mage.IsDead();
        }
    }
}
