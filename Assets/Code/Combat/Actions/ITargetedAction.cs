using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions
{
    interface ITargetedAction
    {
        void SetTarget(Combatant combatant);
    }
}
