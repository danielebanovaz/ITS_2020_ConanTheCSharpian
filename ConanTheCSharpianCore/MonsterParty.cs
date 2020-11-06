

using System;
using System.Collections.Generic;

namespace ConanTheCSharpian.Core
{
    public class MonsterParty : Party<Monster>
    {
        public MonsterParty(Battlefield battlefield, ICharacterController characterController, int numOfMembers)
               : base(battlefield, characterController, numOfMembers)
        { }

        protected override void CreateCharacterInstances(int numOfMembers)
        {
            for (int i = 0; i < numOfMembers; i++)
            {
                MonsterType category = (MonsterType)Rand.Next(Enum.GetNames(typeof(MonsterType)).Length);
                switch (category)
                {
                    case MonsterType.Goblin:
                        Characters.Add(new Goblin());
                        break;
                    case MonsterType.Troll:
                        Characters.Add(new Troll());
                        break;
                    case MonsterType.Warlock:
                        Characters.Add(new Warlock());
                        break;
                }
            }
        }
    }

    public enum MonsterType
    {
        Troll,
        Goblin,
        Warlock
    }
}
