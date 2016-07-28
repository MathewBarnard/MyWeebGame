using UnityEngine;
using System.Collections;

namespace CustomDebug
{
    public class BattleConfigSetting : MonoBehaviour
    {

        private Combatant combatant;
        public BattleConfigurationType tacticPreset;

        void Awake()
        {
            combatant = this.gameObject.GetComponent<Combatant>();
        }


    }
}
