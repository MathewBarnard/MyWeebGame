using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spellbook.Abilities;

namespace Spellbook
{
    public class Spellbook
    {
        private List<Ability> abilities;

        public Spellbook()
        {
            Managers.BattleEvents.battleTickEventHandler += UpdateCooldowns;

            // TEMPORARY
            // We are loading in the spellbook by hand for each character at the moment
            abilities = new List<Ability>();
            abilities.Add(new Melee());
        }

        private void UpdateCooldowns(float deltaTime)
        {
            // Update the cooldown for each spell in this characters spell book
            foreach(Abilities.Ability ability in this.abilities)
            {
                ability.ReduceCooldown(deltaTime);
            }
        }

        // TEMPORARY FUNCTION
        // Get spell is very inefficient. It polls the entire characters spell book and performs a string
        // comparison to find the spell. This should be modified so that it is type safe.
        public Ability GetSpell(string spellName)
        {
            foreach(Ability ability in this.abilities)
            {
                if(ability.Name == spellName)
                {
                    return ability;
                }
            }

            return null;
        }
    }
}
