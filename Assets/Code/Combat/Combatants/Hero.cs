using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : Combatant {

    public override void Awake()
    {
        base.Awake();

        // TEMPORARY: Add a tactic to this character to test if it works!
        this.tactics = new List<Tactics.Tactic>();

        // A battle config has been set in the editor, so load the tactics based on the defined preset
        if (this != null)
            this.tactics = CustomDebug.BattleConfiguration.LoadTactics(this, this.battleConfig.tacticPreset);
    }

    public override void Start()
    {
        base.Start();

        IsFriendly = true;
        actionLocked = false;
    }

    void Update()
    {
        // If this character is not currently locked out in another action, we perform this.
        if (!actionLocked)
        {
            // If there are no actions, update the combatant
            this.stats.Update();

            // Retrieve the associated ability 
            Spellbook.Abilities.Ability ability = GetActiveTactic();

            // Send the combatant and the ability to the ability manager to resolve script attachment
            if (ability != null)
            {
                // Only attach the scripts if the ability isn't on cooldown
                if (ability.Cooldown <= 0.0f)
                {
                    Spellbook.Abilities.AbilityManager.AttachScripts(this, ability);
                    actionLocked = true;
                }
            }
            else
            {
                Debug.LogWarning("ability is null");
            }
        }
    }

    // Returns the first active tactic within this combatants list of active tactics
    private Spellbook.Abilities.Ability GetActiveTactic()
    {
        foreach (Tactics.Tactic tactic in tactics)
        {
            if (tactic.IsTriggered)
            {
                return tactic.AbilityEquipped;
            }
        }

        return null;
    }
}
