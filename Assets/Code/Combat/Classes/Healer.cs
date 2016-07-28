using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Healer : CombatClass
{
    public Healer(Combatant combatant)
        : base(combatant)
    {
    }

    public override void ApplyStats()
    {
        throw new NotImplementedException();
    }

    public override CombatAction[] AutoBattle(Combatant combatant)
    {
        return HealAlly();
    }

    public override CombatAction GetNewTargetAction()
    {
        return null;
    }

    private CombatAction[] HealAlly()
    {
        CombatAction[] actions = new CombatAction[2];

        actions[0] = combatant.gameObject.AddComponent<BasicRangedHeal>();
        actions[1] = combatant.gameObject.AddComponent<NewTurn>();

        return actions;
    }
}
