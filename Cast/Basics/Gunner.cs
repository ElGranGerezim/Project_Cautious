using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Base class for entities with health that attack
    /// </summary>
    public abstract class Gunner : Actor {
        public Gunner(){
            _isVisible = true;
        }
        protected int _health;
        protected int _framesSinceLastAttack;
        protected patternName _attack;
        public abstract void TakeDamage();

        public virtual AttackPattern Attack(){
            _framesSinceLastAttack = 0;
            return FirePattern.getFirePattern(_attack);
        }

        public virtual bool CanFire(){ return _framesSinceLastAttack >= FirePattern.getFirePattern(_attack)._cooldown; }
        public virtual void UpdateLastFire(){_framesSinceLastAttack ++;}

        public int GetHealth(){return _health;}

    }
}