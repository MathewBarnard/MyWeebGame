using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MoveToTargetDefensively : CombatAction
{
    private Vector3 targetLocation;
    public Vector3 TargetLocation
    {
        get { return targetLocation; }
        set { targetLocation = value; }
    }

    void Update()
    {
        // Move this combatant towards the target location
        this.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(this.transform.position, targetLocation, 0.5f * Time.deltaTime));
        // Check if the combatant has arrived at their location. if they have, remove the script.
        if (Vector3.Distance(this.transform.position, targetLocation) < 0.1f)
        {
            complete = true;
        }
    }
}