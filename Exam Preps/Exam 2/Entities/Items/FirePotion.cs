using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class FirePotion:Item
    {
        public FirePotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.Health>0)
            {
                character.Health -= 20;
            }
            else if (character.Health<0)
            {
                character.IsAlive = false;
            }
            
           
        }
    }
}
