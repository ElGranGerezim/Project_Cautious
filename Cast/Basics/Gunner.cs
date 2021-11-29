using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Base class for entities with health that attack
    /// </summary>
    public class Gunner : Actor {
        public Gunner(){
            _isVisible = true;
        }

        protected int _health;

        public virtual void TakeDamage(){}

        public virtual void Attack(){}

        public int GetHealth(){return _health;}

    }
}