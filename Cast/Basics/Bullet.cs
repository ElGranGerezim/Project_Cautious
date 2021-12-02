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
            SetPosition(location);
            SetVelocity(velocity);
            SetWidth(Constants.DEFAULT_BULLET_SIZE);
            SetHeight(Constants.DEFAULT_BULLET_SIZE);
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