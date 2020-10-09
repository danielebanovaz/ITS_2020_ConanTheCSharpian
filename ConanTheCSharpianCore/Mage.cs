

namespace ConanTheCSharpian.Core
{
    public class Mage : Hero
    {
        public Mage()
        {
            Name = "Vlad";
            Damage = 18;
            MaxHealth = 50;
            Accuracy = 0.85f;
        }

        public override void PerformSpecialAction()
        {
            // TODO: implement special action logic
            throw new System.NotImplementedException();
        }
    }
}
