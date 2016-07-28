using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tactics.Self
{
    abstract class SelfTactic : Tactic
    {
        // The combatant whom this tactic is monitoring
        protected Combatant combatant;

        public SelfTactic(Spellbook.Abilities.Ability ability, Combatant combatant)
            :base(ability)
        {
            this.combatant = combatant;
        }
    }
}
