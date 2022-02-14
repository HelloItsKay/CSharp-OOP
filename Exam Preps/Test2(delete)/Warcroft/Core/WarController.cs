    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characterParty;
        private readonly Stack<Item> itemPool;
        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            if (args[0] == "Warrior")
            {
                characterParty.Add(new Warrior(args[1]));
            }
            else if (args[0] == "Priest")
            {
                characterParty.Add(new Priest(args[1]));
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            return string.Format(SuccessMessages.JoinParty, args[1]);

            //YES
           // throw new NotImplementedException();
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (itemName == "HealthPotion")
            {
                itemPool.Push(new HealthPotion());
            }
            else if (itemName == "FirePotion")
            {
                itemPool.Push(new FirePotion());
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            return string.Format(SuccessMessages.AddItemToPool, itemName);

            //NO

            throw new NotImplementedException();
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character desiredCharacter = characterParty.FirstOrDefault(n => n.Name == characterName);
            if (desiredCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName.ToString()));
            }
            else if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = itemPool.Pop();
            desiredCharacter.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, desiredCharacter.Name, item.GetType().Name);

            //NO

          //  throw new NotImplementedException();
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character desiredCharacter = characterParty.FirstOrDefault(n => n.Name == characterName);
            if (desiredCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
            }

            Item desiedItem = desiredCharacter.Bag.GetItem(itemName);
            desiredCharacter.UseItem(desiedItem);
            return string.Format(SuccessMessages.UsedItem,characterName,itemName);

            // NO

           // throw new NotImplementedException();
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString().TrimEnd();

            //  NO

         //   throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string recieverName = args[1];

            Character attacker = characterParty.FirstOrDefault(n => n.Name == attackerName);
            Character reciever = characterParty.FirstOrDefault(n => n.Name == recieverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }

            Warrior warrior = attacker as Warrior;
            if (warrior == null)
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

            warrior.Attack(reciever);
            string output = string.Format(SuccessMessages.AttackCharacter, warrior.Name, reciever.Name, warrior.AbilityPoints,
                reciever.Name, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor);
            if (reciever.Health == 0)
            {
                string temp = string.Format(SuccessMessages.AttackKillsCharacter, reciever.Name);
                output = $"{output}\n{temp}";

            }
            return output;
            // NO
           // throw new NotImplementedException();

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string recieverName = args[1];
            Character healer = characterParty.FirstOrDefault(c => c.Name == healerName);
            Character reciever = characterParty.FirstOrDefault(c => c.Name == recieverName);
            if (healer == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }

            if (reciever == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, recieverName);
            }
            Priest priest = healer as Priest;

            if (priest == null)
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }


            return string.Format(SuccessMessages.HealCharacter, priest.Name, reciever.Name, priest.AbilityPoints,
                reciever.Name, reciever.Health = reciever.Health + priest.AbilityPoints);

            //throw new NotImplementedException();
            
        }
    }
}
