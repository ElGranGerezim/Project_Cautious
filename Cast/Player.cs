using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Class to store data about the player.
    /// </summary>
    public class Player : Gunner {
        private bool _shouldFire = false;
        private bool _focusing = false;

        public Player(){
            SetWidth(Constants.DEFAULT_SQUARE_SIZE);
            SetHeight(Constants.DEFAULT_SQUARE_SIZE);
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y - _height * 2));
        }

        public override void TakeDamage()
        {
            
        }

        public override void Attack()
        {
            
        }

        public void setShouldFire(bool attackInput){
            _shouldFire = attackInput;
        }

        public bool getShouldFire(){
            return _shouldFire;
        }

        public void setFocusing(bool focusInput) {
            _focusing = focusInput;
        }

        public override void SetVelocity(Point newVelocity)
        {
            _velocity = newVelocity.Scale(getCurrentSpeed());
        }

        private int getCurrentSpeed(){
            if (_focusing){
                return Constants.PLAYER_SPEED_FOCUSING;
            }
            return Constants.DEFAULT_PLAYER_SPEED;
        }
    }
}