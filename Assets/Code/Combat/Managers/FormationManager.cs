using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public enum Row { FRONT, MIDDLE, BACK };

    public class FormationManager
    {
        private List<Combatant> frontRow;
        private List<Combatant> middleRow;
        private List<Combatant> backRow;

        public FormationManager()
        {
            this.frontRow = new List<Combatant>();
            this.middleRow = new List<Combatant>();
            this.backRow = new List<Combatant>();
        }

        /// <summary>
        /// Move a combatant to the row specified
        /// </summary>
        /// <param name="combatant"></param>
        /// <param name="row"></param>
        public void MoveToRow(Combatant combatant, Row row)
        {
            // Remove the combatant from their current row
            bool removed = FindAndRemove(combatant);

            switch(row)
            {
                case Row.FRONT:
                    frontRow.Add(combatant);
                    break;
                case Row.MIDDLE:
                    middleRow.Add(combatant);
                    break;
                case Row.BACK:
                    backRow.Add(combatant);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Move the specified combatant back one row
        /// </summary>
        /// <param name="combatant"></param>
        public void MoveBack(Combatant combatant)
        {

        }

        /// <summary>
        /// Find the specified combatant and remove them from their current row
        /// </summary>
        /// <param name="combatant"></param>
        /// <returns></returns>
        public bool FindAndRemove(Combatant combatant)
        {
            // Front row
            foreach (Combatant com in this.frontRow)
            {
                if (com == combatant)
                {
                    frontRow.Remove(combatant);
                    return true;
                }
            }

            // Middle row
            foreach (Combatant com in this.middleRow)
            {
                if (com == combatant)
                {
                    middleRow.Remove(combatant);
                    return true;
                }
            }

            // Back row
            foreach (Combatant com in this.backRow)
            {
                if (com == combatant)
                {
                    backRow.Remove(combatant);
                    return true;
                }
            }

            return false;
        }
    }
}
