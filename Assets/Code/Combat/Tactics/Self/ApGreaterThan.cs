using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Spellbook.Abilities;

namespace Tactics.Self
{
    class ApGreaterThan : SelfTactic
    {
        // The value that defines how much AP the combatant must have for the tactic to trigger.
        private float apValue;

        public ApGreaterThan(Combatant combatant, Ability ability, float apValue)
            :base(ability, combatant)
        {
            this.apValue = apValue;
            Managers.BattleEvents.battleTickEventHandler += CheckTrigger;
        }

        public void CheckTrigger(float deltaTime)
        {
            if(this.combatant.Stats.ActionPoints >= apValue)
            {
                Debug.Log("Triggered");
                this.isTriggered = true;
            }
            else
            {
                this.isTriggered = false;
            }
        }
    }
}
