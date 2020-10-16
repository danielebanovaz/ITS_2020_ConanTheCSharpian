using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public abstract class Character
    {
        #region Fields

        /// <summary>
        /// Name of the Character
        /// </summary>
        protected string Name;

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

        #endregion Fields

        #region Actions

        public void PerformBaseAttack()
        {
            // TODO: I have to implement that
        }

        public abstract void PerformSpecialAction();

        #endregion Actions

        #region Getters and setters

        /// <summary>
        /// Get class name for this character
        /// I.E.: "Mage", "Barbarian", "Troll"...
        /// </summary>
        private string GetCategory()
        {
            return GetType().Name;
        }

        /// <summary>
        /// Get a fully qualified name for the character, using Name and Category.
        /// I.E.: "Gandalf, the Mage"
        /// </summary>
        public string GetFullyQualifiedName()
        {
            return $"{Name}, the {GetCategory()}";
        }

        public bool IsDead()
        {
            return _currentHealth <= 0;
        }

        public float GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void SetCurrentHealth(float health)
        {
            if (health > MaxHealth)
                health = MaxHealth;

            if (IsDead())
                return;

            _currentHealth = health;
        }

        #endregion Getters and setters
    }
}
