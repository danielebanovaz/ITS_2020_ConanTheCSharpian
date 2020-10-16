using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public abstract class Character
    {
        private static Random _random = new Random();

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
        /// Character controller currently in charge of controlling this character
        /// </summary>
        private ICharacterController _controller;

        /// <summary>
        /// Battlefield in which this character acts
        /// </summary>
        private Battlefield _battlefield;

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
            }
        }

        /// <summary>
        /// Get class name for this character
        /// I.E.: "Mage", "Barbarian", "Troll"...
        /// </summary>
        private string Category { get { return GetType().Name; } }

        /// <summary>
        /// Get a fully qualified name for the character, using Name and Category.
        /// I.E.: "Gandalf, the Mage"
        /// </summary>
        public string FullyQualifiedName => $"{Name}, the {Category}"; // even more condensed way of writing get { return ... }

        public bool IsDead
        {
            get
            {
                return _currentHealth <= 0;
            }
        }

        #endregion Fields & Properties

        public void Initialize(Battlefield battlefield, ICharacterController controller)
        {
            _battlefield = battlefield;
            _controller = controller;
            CurrentHealth = MaxHealth;
        }

        #region Actions

        public void PerformBaseAttack()
        {
            List<Character> validTargets = _battlefield.GetValidTargets(this, TargetType.Opponents);
            int randomIndex = _random.Next(0, validTargets.Count - 1);
            Character target = validTargets[randomIndex];

            if (_random.NextDouble() > Accuracy)
            {
                // TODO: move to Client
                Console.WriteLine($"{FullyQualifiedName} missed his attack against {target.FullyQualifiedName}.");
                return;
            }

            target.CurrentHealth -= Damage;
            // TODO: move to Client
            Console.WriteLine($"{FullyQualifiedName} attacked {target.FullyQualifiedName} for {Damage} damage.");
        }

        public abstract void PerformSpecialAction();

        #endregion Actions
    }

    public enum CharacterType
    {
        Barbarian,
        Ranger,
        Mage,
        Troll,
        Goblin,
        Warlock
    }

}
