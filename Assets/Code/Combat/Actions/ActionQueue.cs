using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ActionQueue : MonoBehaviour
{
    // The actions currently in the queue
    private Queue<CombatAction> actions;

    public CombatAction CurrentAction
    {
        get
        {
            if (actions.Count > 0)
                return actions.Peek();
            else
                return null;
        }
    }

    void Awake()
    {
        actions = new Queue<CombatAction>();
    }

    void Start()
    {
        actions = new Queue<CombatAction>();
    }

    void Update()
    {
        if (actions.Count > 0)
        {
            if (actions.Peek().Complete == true)
            {
                CombatAction action = actions.Dequeue();
                Destroy(action);

                // Enable the next action in the queue
                if (actions.Count > 0)
                {
                    actions.Peek().enabled = true;
                }
            }

        }
    }

    public int NumberOfActions()
    {
        return actions.Count;
    }

    // Adds an action to the end of the queue
    public void AddAction(CombatAction action)
    {
        if(action != null)
            this.actions.Enqueue(action);
    }

    public void AddActions(CombatAction[] actionsToQueue)
    {
        if (actionsToQueue != null)
        {
            bool noPendingActions;

            if (this.actions.Count == 0)
            {
                noPendingActions = true;
            }
            else
            {
                noPendingActions = false;
            }

            foreach (CombatAction combatAction in actionsToQueue)
            {
                this.actions.Enqueue(combatAction);
            }

            if (noPendingActions)
            {
                this.actions.Peek().enabled = true;
            }
        }
    }

    // Removes all currently queue'd actions and sets a default
    public void SetAction(CombatAction action)
    {

        foreach (CombatAction queuedAction in actions)
        {
            Destroy(queuedAction);
        }

        actions.Clear();
        actions.Enqueue(action);

        if(actions.Count > 0)
            actions.Peek().enabled = true;
    }

    public void SetActions(CombatAction[] actionsToQueue)
    {
        try {

            foreach (CombatAction queuedAction in actions)
            {
                Destroy(queuedAction);
            }

            actions.Clear();

            foreach (CombatAction action in actionsToQueue)
            {
                actions.Enqueue(action);
            }

            if (actions.Count > 0)
                actions.Peek().enabled = true;
        }
        catch(Exception e)
        {
            Debug.Log("Null combat action passed.");
        }
    }
}