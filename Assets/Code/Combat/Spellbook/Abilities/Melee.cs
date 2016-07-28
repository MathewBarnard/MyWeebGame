using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This represents a single combatant moving into melee range of an enemy, and then attack them.
namespace Spellbook.Abilities
{
    class Melee : Attack
    {
        private const float defaultCooldown = 2.0f;

        public Melee()
        {
            this.name = "Melee";

            // Default base cooldown of 2 seconds for basic attacks
            SetBaseCooldown(defaultCooldown);
            this.cooldown = 0.0f;
        }

        public override Type[] GetActions()
        {
            Type[] actions = new Type[2];

            actions[0] = typeof(AttackMelee);
            actions[1] = typeof(NewTurn);
        
            return actions;
        }
    }
}
