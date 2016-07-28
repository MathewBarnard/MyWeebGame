using UnityEngine;
using System.Collections;

public class DamageCalculator {

	public static int InflictDamage(Combatant target, int damage)
    {
        if (damage < 0)
        {
            return 0;
        }
        else
        {
            return target.Stats.HealthPoints = target.Stats.HealthPoints - damage;
        }
    }

    public static int RemoveDamage(Combatant target, int healAmount)
    {
        return target.Stats.HealthPoints = target.Stats.HealthPoints + healAmount;
    }

    public static int CalculatePhysicalDamage(int attack, int defense)
    {
        return attack - (defense / 2);
    }
}
