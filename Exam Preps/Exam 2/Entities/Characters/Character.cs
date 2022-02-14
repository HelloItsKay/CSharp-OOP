using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        private double abilityPoints;

        protected Character(string name, double baseHealth, double baseArmor,double abilityPoints, Bag bag)

        {

            Name = name;

            BaseHealth = baseHealth;

            BaseArmor = baseArmor;

            Health = BaseHealth;

            Armor = BaseArmor;

            AbilityPoints = abilityPoints;
            Bag = bag;

        }
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth { get; }
        public double BaseArmor { get; }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; }
        public bool IsAlive { get; set; } = true;

        public virtual void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if(hitPoints > Armor)
            {
                Health -= hitPoints - Armor;
            }
            Armor -= hitPoints;
            if (Health is 0)
            {
                IsAlive = false; 
            }
        }


        public virtual void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}