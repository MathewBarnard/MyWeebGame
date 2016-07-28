using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The touch manager is effectively the interface between the player and the game. It handles inputs from the player and translates that
// into an appropriate context based on the type of input, and the location
// As this is a mobile game, we can assume that the only control method will be touch/mouse.
public class TouchManager : MonoBehaviour, IController {

    private List<GameObject> touchableObjects;

	// Use this for initialization
	void Start () {
        touchableObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        GameObject touchedObject = GetTouch();

        if(touchedObject != null)
        {
            Debug.Log(touchedObject.name);
        }
	}

    // Get any touches this pass
    public GameObject GetTouch()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray);

            for (int j = 0; j < hits.Length; j++)
            {
                Controller objectController = hits[i].collider.gameObject.GetComponent<Controller>();

                if (objectController != null)
                {
                    objectController.enabled = true;
                }
            }
        }

        return null;
    }
}
