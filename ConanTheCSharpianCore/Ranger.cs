

namespace ConanTheCSharpian.Core
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            Name = "Drizzt";
            Damage = 15;
            MaxHealth = 85;
            Accuracy = 0.95f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            throw new System.NotImplementedException();
        }
    }
}
