

namespace ConanTheCSharpian.Core
{
    public class Warlock : Monster
    {
        public Warlock()
        {
            Name = "Saruman";
            Damage = 15;
            MaxHealth = 70;
            Accuracy = 0.7f;
        }

        public override void PerformSpecialAction()
        {
            // OLD, CLUMSY WAY:
            //float modifiedHealth = GetCurrentHealth();
            //modifiedHealth += 5;
            //SetCurrentHealth(modifiedHealth);

            // MORE READABLE, USING PROPERTIES
            CurrentHealth += 5;


            // TODO: implement special action logic
            throw new System.NotImplementedException();
        }
    }
}
