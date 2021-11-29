using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Basics{
    /// <summary>
    /// Base class for all bullets in the game
    /// </summary>
    public class Bullet : Actor {
        protected int _damage;
        protected bool _playerFriendly;
        public Bullet(){
            _isVisible = true;
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            SetWidth(Constants.DEFAULT_SQUARE_SIZE/2);
            SetHeight(Constants.DEFAULT_SQUARE_SIZE/2);
            _color = Raylib_cs.Color.WHITE;
        }

        public override bool canGetHit()
        {
            return true;
        }
    }
}