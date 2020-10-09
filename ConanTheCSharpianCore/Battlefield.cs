

namespace ConanTheCSharpian.Core
{
    public class Battlefield
    {
        private HeroParty _heroes = new HeroParty();
        private MonsterParty _monsters = new MonsterParty();

        private bool IsGameFinished()
        {
            return _heroes.IsEverybodyDead() || _monsters.IsEverybodyDead();
        }

        public void UseNextCharacter()
        {
            // TODO: implement that
            throw new System.NotImplementedException();
        }
    }
}
