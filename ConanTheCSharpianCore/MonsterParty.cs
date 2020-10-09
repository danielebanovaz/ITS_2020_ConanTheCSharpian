

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : IParty
    {
        private Goblin _goblin = new Goblin();
        private Troll _troll = new Troll();
        private Warlock _warlock = new Warlock();

        public bool IsEverybodyDead()
        {
            return _goblin.IsDead() && _troll.IsDead() && _warlock.IsDead();
        }
    }
}
