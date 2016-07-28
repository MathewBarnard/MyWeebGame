using UnityEngine;
using System.Collections;

namespace Spells
{
    public abstract class Spell : MonoBehaviour
    {
        protected bool resolved;
        public bool IsResolved
        {
            get { return resolved; }
            set { resolved = value; }
        }

        protected Combatant source;
        public Combatant Source
        {
            get { return source; }
            set { source = value; }
        }

        protected void Resolve()
        {
            this.resolved = true;
            Destroy(this.gameObject);
        }
    }
}
