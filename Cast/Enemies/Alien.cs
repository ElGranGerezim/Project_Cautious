using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class Alien : Enemy{
        public Alien(Point position){
            _health = 5;
            _attack = patternName.V;
            _color = Raylib_cs.Color.PURPLE;
            SetPosition(position);
        }

        public override void Move(Point playerPos){
            //It doesn't move
        }
    }
}