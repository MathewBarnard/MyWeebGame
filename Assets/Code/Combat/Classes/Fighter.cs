using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Fighter : CombatClass {

    public Fighter(Combatant combatant)
        : base(combatant)
    {
    }

    public override void ApplyStats()
    {
        throw new NotImplementedException();
    }

    public override CombatAction[] AutoBattle(Combatant combatant)
    {
        // Attack by default
        return AttackSingleEnemy();
    }

    private CombatAction[] AttackSingleEnemy()
    {
        CombatAction[] actions = new CombatAction[3];

        actions[0] = combatant.gameObject.AddComponent<MoveToCombatant>();
        actions[1] = combatant.gameObject.AddComponent<AttackMelee>();
        actions[2] = combatant.gameObject.AddComponent<NewTurn>();

        return actions;
    }

    public override CombatAction GetNewTargetAction()
    {
        MoveToTargetDefensively action = combatant.gameObject.AddComponent<MoveToTargetDefensively>();
        action.TargetLocation = this.combatant.Target.transform.position;
        return action;
    }
}

