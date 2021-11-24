using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Class to store data about the player.
    /// </summary>
    public class Player : Gunner {
        public Player(){
            _width = Constants.DEFAULT_SQUARE_SIZE;
            _height = Constants.DEFAULT_SQUARE_SIZE;
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y - _height * 2));
        }

        public override void TakeDamage()
        {
            
        }

        public override void Attack()
        {
            
        }
    }
}