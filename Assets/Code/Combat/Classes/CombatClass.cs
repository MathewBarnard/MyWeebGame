using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class CombatClass {

    // A reference to the combatant who owns this class instance
    public Combatant combatant;

    // This applies stat modifications to the Combatants base stats based on the class
    public abstract void ApplyStats();

    // This determines the ideal auto battle behaviour
    public abstract CombatAction[] AutoBattle(Combatant combatant);

    public CombatClass(Combatant combatant)
    {
        this.combatant = combatant;
    }

    public abstract CombatAction GetNewTargetAction();
}

