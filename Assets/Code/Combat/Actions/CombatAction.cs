using UnityEngine;
using System.Collections;
using Spellbook.Abilities;


public abstract class CombatAction : MonoBehaviour
{
    protected Combatant combatant;  // The combatant performing the combat action
    protected Ability ability;      // The ability associated with this combat action.

    protected bool complete = false;
    public bool Complete
    {
        get { return complete; }
        set { complete = value; }
    }

    protected int id;
    public int Id
    {
        get { return id; }
    }

    public virtual void Awake()
    {
        combatant = this.gameObject.GetComponent<Combatant>();
        this.enabled = false;
    }

    // Sets the ability within a combatants Spellbook that is associated with this action
    public void SetAbility(Ability ability)
    {
        this.ability = ability;
    }
}
