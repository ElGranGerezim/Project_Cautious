using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    public class FastMob : Enemy{
        public FastMob(Point position){
            _health = 2;
            _attack = patternName.SingleFast;
            _color = Raylib_cs.Color.ORANGE;
            SetPosition(position);
            SetImage(Constants.MOB_IMAGE);
            SetWidth(70);
            SetHeight(47);
        }

        public override void Move(Point playerPos){ //It doesnt move
        }
    }
}