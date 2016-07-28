using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spellbook.Abilities;

namespace Tactics
{
    public abstract class Tactic
    {
        // The ability associated with this tactic
        protected Ability ability;
        public Ability AbilityEquipped
        {
            get { return ability; }
        }

        // Indicates whether the condition for this tactic has been triggered or not
        protected bool isTriggered;
        public bool IsTriggered
        {
            get { return isTriggered; }
        }

        public Tactic(Ability ability)
        {
            this.ability = ability;
        }
    }
}
