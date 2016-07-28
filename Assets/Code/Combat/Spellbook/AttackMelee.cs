using UnityEngine;
using System.Collections;

namespace Spells
{ 
    public class AttackMelee : Spell
    {
        void OnTriggerEnter(Collider col)
        {
            if (!this.resolved)
            {
                Combatant combatantHit = col.gameObject.GetComponent<Combatant>();

                if (combatantHit != null)
                {
                    if (!combatantHit.IsFriendly)
                    {
                        int damage = DamageCalculator.CalculatePhysicalDamage(Source.Stats.AttackPower, combatantHit.Stats.Defense);

                        DamageCalculator.InflictDamage(combatantHit, damage);

                        Resolve();
                    }
                }
            }
        }
    }
}