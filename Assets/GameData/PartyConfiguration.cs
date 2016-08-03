using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    public class PartyConfiguration
    {
        private List<Character> charactersInParty;
        public List<Character> CharactersInParty
        {
            get { return charactersInParty; }
        }

        private List<Character> frontRow;
        public List<Character> FrontRow
        {
            get { return frontRow; }
        }

        private List<Character> middleRow;
        public List<Character> MiddleRow
        {
            get { return middleRow; }
        }

        private List<Character> backRow;
        public List<Character> BackRow
        {
            get { return backRow; }
        }

        public PartyConfiguration()
        {
            charactersInParty = new List<Character>();
            frontRow = new List<Character>();
            middleRow = new List<Character>();
            backRow = new List<Character>();
        }
    }
}
