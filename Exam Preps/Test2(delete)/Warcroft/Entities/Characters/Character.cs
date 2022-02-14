using System;
using System.Collections.Concurrent;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            // maybe boom
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        private string name;

        private double health;

        private double armor;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }

        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;

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

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
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

        public double AbilityPoints { get; }

        public Bag Bag { get; }


        public bool IsAlive { get; set; } = true;


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public virtual void TakeDamage(double hitPoints)
        {
            EnsureAlive();


            if (hitPoints > Armor)
            {
                Health -= hitPoints - Armor;
            }
            Armor -= hitPoints;

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            EnsureAlive();

            // ne e siguren kay :)
            item.AffectCharacter(this);
        }

    }
}