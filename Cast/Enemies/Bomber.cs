using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class Bomber : Enemy{
        public Bomber(){
            _health = 5;
            _attack = patternName.Triple;
            _color = Raylib_cs.Color.RED;
            SetPosition(new Point(Constants.CENTER_X, _height));
        }
    }
}