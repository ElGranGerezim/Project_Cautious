using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    /// <summary>
    /// Base class for all bullets in the game
    /// </summary>
    public class Bullet : Actor {
        protected int _damage;
        protected bool _playerFriendly;
        public Bullet(){
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            _color = Raylib_cs.Color.WHITE;
        }
    }
}