using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Managers {
    public class BattleManager : MonoBehaviour {

        // Singleton
        private static BattleManager instance;
        public static BattleManager Instance
        {
            get { return instance; }
        }

        private List<Combatant> playerCombatants = new List<Combatant>();
        private List<Combatant> enemyCombatants = new List<Combatant>();

        private FormationManager allyFormation;
        public FormationManager AllyFormation
        {
            get { return allyFormation; }
        }
        private FormationManager enemyFormation;
        public FormationManager EnemyFormation
        {
            get { return enemyFormation; }
        }

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            // Load all combatants 
            playerCombatants = new List<Combatant>();
            enemyCombatants = new List<Combatant>();

            // We find all of the combatants within the stage and assign them to the correct list
            GameObject[] combatantObjects = GameObject.FindGameObjectsWithTag("Combatant");

            foreach (GameObject obj in combatantObjects)
            {
                // Get the Combatant Script from this GameObject
                Combatant combatant = obj.GetComponent<Combatant>();

                if (combatant != null)
                {
                    // Add the combatant to the appropriate list based on their allegiance
                    if (combatant.IsFriendly)
                    {
                        playerCombatants.Add(combatant);
                    }
                    else
                    {
                        enemyCombatants.Add(combatant);
                    }
                }
            }
        }

        // The BattleManager update is used to compile battle data such as the length of the fight as well as 'tick' timers for calling events. 
        // For example; we only want to call specific events per second rather than every update.
        void Update()
        {
            try {
                if (BattleEvents.battleTickEventHandler != null)
                {
                    BattleEvents.battleTickEventHandler(Time.deltaTime);
                }
                else
                {
                    throw new UnassignedReferenceException("battleTickEventHandler is null.");
                }
            }
            catch(UnassignedReferenceException e)
            {
                Debug.Log(e.Message);
            }
        }

        public List<Combatant> GetAllCombatants()
        {
            return null;
        }

        public List<Combatant> GetAllyCombatants()
        {
            return playerCombatants;
        }

        public List<Combatant> GetEnemyCombatants()
        {
            return enemyCombatants;
        }
    }
}
