using UnityEngine;
using System.Collections;

public class NewTurn : CombatAction {

    public override void Awake()
    {
        base.Awake();
    }

	void Start()
    {
        this.gameObject.GetComponent<Combatant>().ActionLocked = false;
        this.complete = true;
        this.ability.PutOnCooldown();
    }
}
