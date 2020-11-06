﻿

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
            // TODO: implement special action logic

            DamageSp = Damage ;
            AccuracySp = Accuracy ;
            Battlefield.DisplayMessage($"{FullyQualifiedName} just used his special action!");
            // TODO: implement his special action
        }
    }
}
