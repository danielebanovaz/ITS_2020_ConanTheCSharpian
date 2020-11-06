using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public abstract class Character
    {
        public static Random _random = new Random();

        #region Fields & Properties

        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name { get; protected set; } // We changed it into a property to give public read access and mantain protected write access


        // ^^^^ This property is written in a compact form; it's equivalent to:
        //
        // private string _verboseNameProperty;
        // public string VerboseNameProperty
        // {
        //     get { return _verboseNameProperty; }
        //     protected set { _verboseNameProperty = value; }
        // }


        /// <summary>
        /// Base damage inflicted by the Character
        /// </summary>
        protected float Damage;

        /// <summary>
        /// Special damage inflicted by the Character during special attack
        /// </summary>
        protected float DamageSp;

        /// <summary>
        /// Maximum health available to the Character
        /// </summary>
        protected float MaxHealth;

        /// <summary>
        /// Current health of the Character
        /// </summary>
        private float _currentHealth;

        /// <summary>
        /// Chance of successfully hitting an opponent during an attack
        /// (expressed in a [0, 1] range)
        /// </summary>
        protected float Accuracy;

        /// <summary>
        /// Chance of successfully hitting an opponent during an special attack
        /// (expressed in a [0, 1] range)
        /// </summary>
        protected float AccuracySp;

        /// <summary>
        /// max energy for special action 
        /// </summary>
        protected float MaxMana;

        /// <summary>
        /// current energy for special action 
        /// </summary>
        private float _currentMana;

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
            protected set
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

        public float CurrentMana
        {
            // Equivalent to "GetCurrentmana()"
            get
            {
                return _currentMana;
            }

            // Equivalent to "SetCurrentmana(value)"
            protected set
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

        #endregion Fields & Properties

        public void Initialize(Battlefield battlefield, ICharacterController controller, string customName = null)
        {
            Battlefield = battlefield;
            _controller = controller;
            _currentHealth = MaxHealth;
            _currentMana = MaxMana;

            if (!string.IsNullOrWhiteSpace(customName))
                Name = customName;
        }

        #region Actions

        internal void Act()
        {
            if (IsDead)
                return;

            _controller.ChooseAttackType(this);
        }

        public void PerformBaseAttack()
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];

            if (_random.NextDouble() > Accuracy)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} for {Damage} damage.");
            target.CurrentHealth -= Damage;
        }

        public virtual void PerformSpecialAction()
        {

            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];

            if (_random.NextDouble() > AccuracySp)
            {
                Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return;
            }

            Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} for {DamageSp} special damage.");
            target.CurrentHealth -= DamageSp;

            // TODO: implement healing for Mage
        }

        public virtual void PerformSpecialActionPaladin()
        {
            List<Character> validTargets = Battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];

            foreach (object i in validTargets)
            {
                if (_currentMana <= 30)
                {
                    Battlefield.DisplayMessage($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}. Not enough Mana");
                    return;
                }

                Battlefield.DisplayMessage($"{FullyQualifiedName} attacked {target.FullyQualifiedName} for {DamageSp} special damage.");
                target.CurrentHealth -= DamageSp;
            }

            _currentMana -= 30;
                
            


            // TODO: implement healing for Paladin
        }


        #endregion Actions
    }

    public enum CharacterType
    {
        Barbarian,
        Ranger,
        Mage,
        Paladin,
        Troll,
        Goblin,
        Warlock
    }

}
