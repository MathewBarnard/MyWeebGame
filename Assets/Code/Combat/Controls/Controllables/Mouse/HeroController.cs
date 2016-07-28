using UnityEngine;
using System.Collections;
using System;

public class HeroController : Controller {

    private ActionQueue actionQueue;

    public override void Activate()
    {
        Debug.Log("HELLO");
    }

    // Use this for initialization
    void Start () {

        actionQueue = this.gameObject.GetComponent<ActionQueue>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonUp(0))
        {
            // Find out which object we are interacting with
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                // We have hit a combatant
                if(hits[i].collider.gameObject.tag == "Combatant")
                {
                    this.gameObject.GetComponent<Combatant>().Target = hits[i].collider.gameObject.GetComponentInParent<Combatant>();
                }
            }

            this.enabled = false;
        }
	}
}
