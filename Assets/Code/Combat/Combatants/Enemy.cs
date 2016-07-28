using UnityEngine;
using System.Collections;

public class Enemy : Combatant {

    public override void Start()
    {
        base.Start();

        IsFriendly = false;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
