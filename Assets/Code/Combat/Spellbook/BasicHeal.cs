using UnityEngine;
using System.Collections;

namespace Spells
{ 
    public class BasicHeal : Spell
    {
        private int healStrength;
        public int HealStrength
        {
            set { healStrength = value; }
            get { return healStrength; }
        }

        private Combatant target;
        public Combatant Target
        {
            set { target = value; }
            get { return target; }
        }

        void Update()
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, BattleConstants.MovementSpeed * Time.deltaTime);
        }

        void OnTriggerEnter(Collider col)
        {
            if (!this.resolved)
            {
                Combatant combatantHit = col.gameObject.GetComponent<Combatant>();

                if (combatantHit != null)
                {
                    if (combatantHit == target)
                    {
                        DamageCalculator.RemoveDamage(combatantHit, this.healStrength);

                        this.resolved = true;

                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}