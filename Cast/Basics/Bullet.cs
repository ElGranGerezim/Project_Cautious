using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Basics{
    /// <summary>
    /// Base class for all bullets in the game
    /// </summary>
    public class Bullet : Actor {
        protected int _damage;
        protected bool _playerFriendly;
        public Bullet(Point location, Point velocity, bool playerFriendly = false){
            _isVisible = true;
            _playerFriendly = playerFriendly;
            SetVelocity(velocity);
            SetWidth(Constants.DEFAULT_BULLET_SIZE);
            SetHeight(Constants.DEFAULT_BULLET_SIZE);
            Point actualLocation = location.Add(new Point(-(_width/2), 0));
            SetPosition(actualLocation);
            _color = Raylib_cs.Color.WHITE;
        }

        public override bool canGetHit()
        {
            return true;
        }
        public bool GetPlayerFriendly(){
            return _playerFriendly;
        }
    }
}