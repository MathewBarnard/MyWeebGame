using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Combatant : MonoBehaviour
{
    // DEBUG BATTLE CONFIGURATION
    // Allows me to set a Battle Configuration for the combatant in the editor
    protected CustomDebug.BattleConfigSetting battleConfig;

    protected Combatant target;
    public Combatant Target
    {
        get { return target; }
        set { target = value; }
    }

    private Spellbook.Spellbook spells;
    public Spellbook.Spellbook Spells
    {
        get { return spells; }
        set { spells = value; }
    }

    protected bool isFriendly;
    public bool IsFriendly
    {
        get { return isFriendly; }
        set { isFriendly = value; }
    }

    protected bool actionLocked;
    public bool ActionLocked
    {
        get { return actionLocked; }
        set { actionLocked = value; }
    }

    protected Stats stats;
    public Stats Stats
    {
        get { return stats; }
    }

    // The heros action queue
    protected ActionQueue actions;
    public ActionQueue Actions
    {
        get { return actions; }
    }

    public CombatAction CurrentAction
    {
        get { return actions.CurrentAction; }
    }

    // TEMPORARY LIST OF TACTICS
    protected List<Tactics.Tactic> tactics;
    public List<Tactics.Tactic> Tactics
    {
        get { return tactics; }
        set { tactics = value; }
    }

    public virtual void Awake()
    {
        // Store a reference to the battle configuration
        if (this.GetComponent<CustomDebug.BattleConfigSetting>() != null)
        {
            this.battleConfig = this.GetComponent<CustomDebug.BattleConfigSetting>();
        }


        this.spells = new Spellbook.Spellbook();

        // Initialise the action queue
        this.actions = this.gameObject.AddComponent<ActionQueue>();
    }

    public virtual void Start()
    {
        // Initialise the characters stat bucket
        stats = new Stats();

        this.GetComponent<SphereCollider>().radius = this.Stats.Range;
    }
}