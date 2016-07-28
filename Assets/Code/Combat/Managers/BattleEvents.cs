using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    class BattleEvents
    {
        public delegate void BattleTick(float deltaTime);
        public static BattleTick battleTickEventHandler;
    }
}
