using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    // A programatical view of a character as stored in XML.
    public class Character
    {
        // The characters stats
        private Stats stats;
        public Stats Statistics
        {
            get { return stats; }
            set { stats = value; }
        }

        public Character()
        {
            stats = new Stats();
        }
    }
}
