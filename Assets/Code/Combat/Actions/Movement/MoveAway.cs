using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MoveAway : CombatAction
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
        this.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(this.transform.position, targetLocation, 3.0f * Time.deltaTime));

        // Check if the combatant has arrived at their location. if they have, remove the script.
        if (Vector3.Distance(this.transform.position, targetLocation) < 0.1f)
        {
            complete = true;
        }
    }
}
