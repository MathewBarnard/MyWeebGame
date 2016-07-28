using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spellbook.Abilities
{
    public abstract class Ability
    {
        public abstract Type[] GetActions();

        protected string name; 
        public string Name
        {
            get { return name; }
        }

        protected float baseCooldown;

        protected float cooldown;
        public float Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        // Sets the base cooldown for the ability
        protected void SetBaseCooldown(float baseCooldown) 
        {
            this.baseCooldown = baseCooldown;
        }

        public void PutOnCooldown()
        {
            cooldown = baseCooldown;
        }

        // Reduces the cooldown of the ability by a specified amount
        public void ReduceCooldown(float time)
        {
            cooldown -= time;

            if(cooldown < 0.0f)
            {
                cooldown = 0.0f;
            }
        }
    }
}
