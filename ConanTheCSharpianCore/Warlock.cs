

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        public Warlock()
        {
            // TODO: change them
            Name = "Conan";
            Damage = 30;
            MaxHealth = 120;
            Accuracy = 0.6f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            throw new System.NotImplementedException();
        }
    }
}
