using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Basics{

    /// <summary>
    /// Base class for all enemies in the game.
    /// </summary>
    public abstract class Enemy : Gunner {
        public Enemy(){
        }

        public override bool canGetHit()
        {
            return true;
        }

        public override void TakeDamage()
        {
            _health --;
        }

        public abstract void Move(Point playerPos);
    }
}