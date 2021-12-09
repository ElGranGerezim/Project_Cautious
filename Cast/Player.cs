using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Class to store data about the player.
    /// </summary>
    public class Player : Gunner {
        private bool _focusing = false;
        private int _iFrames = 0;

        public Player(){
            _health = 5;
            SetWidth(16);
            SetHeight(16);
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y - _height * 2));
            _attack = patternName.Shotgun;
        }

        public override void TakeDamage()
        {
            _iFrames = Constants.FRAME_RATE * 3;
            _health--;
        }

        public override bool canGetHit()
        {
            return _iFrames == 0;
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
                _isVisible = true;
                return Constants.PLAYER_SPEED_FOCUSING;
            }
            _isVisible = false;
            return Constants.DEFAULT_PLAYER_SPEED;
        }

        public override Point GetCenterFire()
        {
            return new Point(_position.GetX() + (_width/2), GetTopEdge());
        }

        public void tickIFrames(){
            if (_iFrames != 0){
                _iFrames --;
                _color = Raylib_cs.Color.RED;
            } else {
                _color = Raylib_cs.Color.DARKBLUE;
            }
        }
    }
}