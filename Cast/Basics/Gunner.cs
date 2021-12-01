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
        protected int _framesSinceLastAttack;
        protected AttackPattern _attack;
        public virtual void TakeDamage(){}

        public virtual AttackPattern Attack(){
            _framesSinceLastAttack = 0;
            return _attack;
        }

        public virtual bool CanFire(){ return _framesSinceLastAttack >= _attack._cooldown; }
        public virtual void UpdateLastFire(){_framesSinceLastAttack ++;}

        public virtual void GetAttackPattern(){}

        public int GetHealth(){return _health;}

    }
}