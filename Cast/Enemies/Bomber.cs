using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class Bomber : Enemy{
        public Bomber(Point position){
            _health = 5;
            _attack = patternName.Triple;
            _color = Raylib_cs.Color.RED;
            SetPosition(position);
        }
    }
}