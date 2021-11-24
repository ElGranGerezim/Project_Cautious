using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    public class Player : Actor {
        public Player(){
            _width = Constants.DEFAULT_SQUARE_SIZE;
            _height = Constants.DEFAULT_SQUARE_SIZE;
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y - _height * 2));
        }
    }
}