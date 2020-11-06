using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public abstract class Character
    {
        protected static Random Random = new Random();
        private const float MANA_REGEN_PER_TURN = 10;

        #region Fields & Properties

        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name { get; private set; } // We changed it into a property to give public read access and mantain private write access


        // ^^^^ This property is written in a compact form; it's equivalent to:
        //
        // private string _verboseNameProperty;
        // public string VerboseNameProperty
        // {
        //     get { return _verboseNameProperty; }
        //     private set { _verboseNameProperty = value; }
        // }


        /// <summary>
        /// Base damage inflicted by the Character
        /// </summary>
        protected float Damage;

        /// <summary>
        /// Maximum health available to the Character
        /// </summary>
        protected float MaxHealth;

        /// <summary>
        /// Current health of the Character
        /// </summary>
        private float _currentHealth;

        /// <summary>
        /// Maximum health mana to the Character
        /// </summary>
        protected float MaxMana;

        /// <summary>
        /// Current mana of the Character
        /// </summary>
        private float _currentMana;

        /// <summary>
        /// Chance of successfully hitting an opponent during an attack
        /// (expressed in a [0, 1] range)
        /// </summary>
        protected float Accuracy;

        /// <summary>
        /// Mana consumed by using the special action
        /// </summary>
        protected float ManaConsumption;

        /// <summary>
        /// Character controller currently in charge of controlling this character
        /// </summary>
        private ICharacterController _controller;

        /// <summary>
        /// Battlefield in which this character acts
        /// </summary>
        protected Battlefield Battlefield { get; private set; }

        /// <summary>
        /// Current health of the character.
        /// Automatically handles Max Health capping and avoids resurrection
        /// </summary>
        public float CurrentHealth
        {
            // Equivalent to "GetCurrentHealth()"
            get
            {
                return _currentHealth;
            }

            // Equivalent to "SetCurrentHealth(value)"
            set
            {
                if (value > MaxHealth)
                    value = MaxHealth;

                if (IsDead)
                    return;

                _currentHealth = value;

                if (IsDead)
                {
                    if (this is Hero)
                        Battlefield.DisplayMessage($"Oh no! {FullyQualifiedName} just perished.");
                    else
                        Battlefield.DisplayMessage($"Yes! That fithy {FullyQualifiedName} has been slained.");
                }
            }
        }

        /// <summary>
        /// Current mana of the character.
        /// Automatically handles Max Mana capping
        /// </summary>
        public float CurrentMana
        {
            get
            {
                return _currentMana;
            }
            private set
            {
                if (value > MaxMana)
                    value = MaxMana;

                _currentMana = value;
            }
        }

        /// <summary>
        /// Get class name for this character
        /// I.E.: "Mage", "Barbarian", "Troll"...
        /// </summary>
        public CharacterType Category { get { return (CharacterType)Enum.Parse(typeof(CharacterType), GetType().Name); } }

        /// <summary>
        /// Get a fully qualified name for the character, using Name and Category.
        /// I.E.: "Gandalf the Mage"
        /// </summary>
        public string FullyQualifiedName => $"{Name} the {Category}"; // even more condensed way of writing get { return ... }

        public bool IsDead
        {
            get
            {
                return _currentHealth <= 0;
            }
        }

        public bool CanUseSpecial
        {
            get
            {
                return ManaConsumption <= CurrentMana;
            }
        }

        public float NextBaseAttackBoost;

        #endregion Fields & Properties

        public void Initialize(Battlefield battlefield, ICharacterController controller, string customName = null)
        {
            Battlefield = battlefield;
            _controller = controller;
            _currentHealth = MaxHealth;
            _currentMana = MaxMana;

            if (string.IsNullOrWhiteSpace(customName))
                customName = GetRandomName();

            Name = customName;
        }

        #region Actions

        internal void Act()
        {
            if (IsDead)
                return;

            if (CanUseSpecial)
            {
                AttackType attackType = _controller.ChooseAttackType(this);
                switch (attackType)
                {
                    case AttackType.BaseAttack:
                        PerformBaseAttack();
                        break;
                    case AttackType.SpecialAction:
                        PerformSpecialAction();
                        CurrentMana -= ManaConsumption;
                        break;
                    default: throw new NotImplementedException();
                }
            }
            else
            {
                PerformBaseAttack();
            }

            CurrentMana += MANA_REGEN_PER_TURN;
        }

        private void PerformBaseAttack()
        {
            float damage = Damage;
            if (NextBaseAttackBoost != 0)
            {
                damage *= NextBaseAttackBoost;
                NextBaseAttackBoost = 0;
            }

            Attack(GetRandomCharacter(), damage, Accuracy);
        }

        protected Character GetRandomCharacter(TargetType targetType = TargetType.Opponents)
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, targetType);
            return Helpers.GetRandomElement(validTargets);
        }

        protected void Attack(Character target, float damage, float accuracy, string messagePrefix = null)
        {
            if (Random.NextDouble() > accuracy)
            {
                Battlefield.DisplayMessage($"{messagePrefix}{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{messagePrefix}{FullyQualifiedName} attacked {target.FullyQualifiedName} for {damage} damage.");
            target.CurrentHealth -= damage;
        }

        protected abstract void PerformSpecialAction();

        #endregion Actions

        private string GetRandomName()
        {
            string name = Helpers.GetRandomElement(_fantasyNames);
            _fantasyNames.Remove(name);
            return name;
        }

        public override string ToString()
        {
            return FullyQualifiedName;
        }

        private static List<string> _fantasyNames = new List<string>()
        {
        "Lydan", "Syrin", "Ptorik", "Joz", "Varog", "Gethrod", "Hezra", "Feron", "Ophni", "Colborn", "Fintis", "Gatlin", "Jinto", "Hagalbar", "Krinn", "Lenox", "Revvyn", "Hodus", "Dimian", "Paskel", "Kontas", "Weston", "Azamarr", "Jather", "Tekren", "Jareth", "Adon", "Zaden", "Eune", "Graff", "Tez", "Jessop", "Gunnar", "Pike", "Domnhar", "Baske", "Jerrick", "Mavrek", "Riordan", "Wulfe", "Straus", "Tyvrik", "Henndar", "Favroe", "Whit", "Jaris", "Renham", "Kagran", "Lassrin", "Vadim", "Arlo", "Quintis", "Vale", "Caelan", "Yorjan", "Khron", "Ishmael", "Jakrin", "Fangar", "Roux", "Baxar", "Hawke", "Gatlen", "Barak", "Nazim", "Kadric", "Paquin", "Kent", "Moki", "Rankar", "Lothe", "Ryven", "Clawsen", "Pakker", "Embre", "Cassian", "Verssek", "Dagfinn", "Ebraheim", "Nesso", "Eldermar", "Rivik", "Rourke", "Barton", "Hemm", "Sarkin", "Blaiz", "Talon", "Agro", "Zagaroth", "Turrek", "Esdel", "Lustros", "Zenner", "Baashar", "Dagrod", "Gentar", "Feston", "Syrana", "Resha", "Varin", "Wren", "Yuni", "Talis", "Kessa", "Magaltie", "Aeris", "Desmina", "Krynna", "Asralyn", "Herra", "Pret", "Kory", "Afia", "Tessel", "Rhiannon", "Zara", "Jesi", "Belen", "Rei", "Ciscra", "Temy", "Renalee", "Estyn", "Maarika", "Lynorr", "Tiv", "Annihya", "Semet", "Tamrin", "Antia", "Reslyn", "Basak", "Vixra", "Pekka", "Xavia", "Beatha", "Yarri", "Liris", "Sonali", "Razra", "Soko", "Maeve", "Everen", "Yelina", "Morwena", "Hagar", "Palra", "Elysa", "Sage", "Ketra", "Lynx", "Agama", "Thesra", "Tezani", "Ralia", "Esmee", "Heron", "Naima", "Rydna", "Sparrow", "Baakshi", "Ibera", "Phlox", "Dessa", "Braithe", "Taewen", "Larke", "Silene", "Phressa", "Esther", "Anika", "Rasy", "Harper", "Indie", "Vita", "Drusila", "Minha", "Surane", "Lassona", "Merula", "Kye", "Jonna", "Lyla", "Zet", "Orett", "Naphtalia", "Turi", "Rhays", "Shike", "Hartie", "Beela", "Leska", "Vemery", "Lunex", "Fidess", "Tisette", "Partha"
        };
    }

    public enum CharacterType
    {
        Barbarian,
        Ranger,
        Mage,
        Paladin,
        Troll,
        Goblin,
        Warlock,
        Necromancer,
        Skeleton
    }

    public enum AttackType
    {
        BaseAttack, SpecialAction
    }
}
