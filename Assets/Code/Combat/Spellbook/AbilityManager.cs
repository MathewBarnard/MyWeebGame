using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Actions;


namespace Spellbook.Abilities
{
    static class AbilityManager
    {
        // This function accepts an ability and a combatant and will attach the scripts as specified by the ability
        public static void AttachScripts(Combatant combatant, Ability ability)
        {
            Type[] actions = ability.GetActions();

            List<CombatAction> actionsToQueue = new List<CombatAction>();

            foreach(Type action in actions)
            {
                // Add the script to the Combatant
                CombatAction combatAction = (CombatAction)combatant.gameObject.AddComponent(action);

                combatAction.SetAbility(ability);

                // If the action is targeted, we set it.
                if(combatAction is ITargetedAction)
                {
                    // Set the target for the combat action
                    ITargetedAction targetedAction = combatAction as ITargetedAction;
                    targetedAction.SetTarget(combatant.Target);
                }

                // Add the target to the queue
                actionsToQueue.Add(combatAction);
            }

            combatant.Actions.AddActions(actionsToQueue.ToArray());
        }
    }
}
