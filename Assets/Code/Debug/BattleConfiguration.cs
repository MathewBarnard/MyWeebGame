using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDebug
{
    public enum BattleConfigurationType
    {
        NONE,
        DEFAULT
    };

    public static class BattleConfiguration
    {
        public static List<Tactics.Tactic> LoadTactics(Combatant combatant, BattleConfigurationType preset)
        {
            switch(preset)
            {
                case BattleConfigurationType.NONE:
                    return null;
                case BattleConfigurationType.DEFAULT:
                    return GetDefault(combatant);
                default:
                    return null;
            }
        }

        public static List<Tactics.Tactic> GetDefault(Combatant combatant)
        {
            List<Tactics.Tactic> tactics = new List<Tactics.Tactic>();

            tactics.Add(new Tactics.Self.ApGreaterThan(combatant, combatant.Spells.GetSpell("Melee"), 50.0f));

            return tactics;
        }
    }
}
