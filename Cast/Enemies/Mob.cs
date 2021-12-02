using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class Mob : Enemy{
        public Mob(){
            _health = 2;
            _attack = patternName.Single;
            _color = Raylib_cs.Color.ORANGE;
            SetPosition(new Point(Constants.CENTER_X / 2, _height));
        }
    }
}