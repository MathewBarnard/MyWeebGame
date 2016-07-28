using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour, IController
{
    private List<GameObject> touchableObjects;

    // Use this for initialization
    void Start()
    {
        // Clean this up later
        touchableObjects = new List<GameObject>(GameObject.FindObjectsOfType<GameObject>());
    }

    // Update is called once per frame
    void Update()
    {

        GameObject touchedObject = GetTouch();

        if (touchedObject != null)
        {
            // We retrieve the context of the object that we have touched, and begin executing it.
        }
    }

    // Get any touches this pass
    public GameObject GetTouch()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray);

            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.tag == "Combatant")
                {
                    Controller objectController = hits[i].collider.gameObject.GetComponentInParent<Controller>();

                    if (objectController != null)
                    {
                        objectController.enabled = true;
                    }
                }
            }
        }

        return null;
    }
}
