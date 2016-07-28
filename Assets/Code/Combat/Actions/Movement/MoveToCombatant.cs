using UnityEngine;
using System.Collections;
using Actions;
using System;

public class MoveToCombatant : CombatAction, ITargetedAction {

    // The target combatant to move towards
    private Combatant target;
    public Combatant Target
    {
        get { return target; }
        set { target = value; }
    }

    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update () {

        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, BattleConstants.MovementSpeed * Time.deltaTime);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == target.gameObject)
        {
            complete = true;
        }
    }

    public void SetTarget(Combatant combatant)
    {
        target = combatant;
    }
}
