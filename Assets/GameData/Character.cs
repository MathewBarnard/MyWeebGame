using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    // A programatical view of a character as stored in XML.
    public class Character
    {
        // The characters name
        private string name;
        public string Name
        {
            get { return name; }
        }

        // The characters stats
        private Stats stats;
        public Stats Statistics
        {
            get { return stats; }
            set { stats = value; }
        }

        // The characters available spells this combat
        private Spellbook.Spellbook spellbook;
        public Spellbook.Spellbook ListOfSpells
        {
            get { return spellbook; }
        }

        private List<Tactics.Tactic> tactics;
        public List<Tactics.Tactic> Tactics
        {
            get { return tactics; }
        }

        public Character()
        {
            stats = new Stats();
            spellbook = new Spellbook.Spellbook();
            tactics = new List<Tactics.Tactic>();
        }
    }
}
