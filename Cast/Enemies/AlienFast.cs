using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class AlienFast : Enemy{
        public AlienFast(Point position){
            _health = 5;
            _attack = patternName.Vfast;
            _color = Raylib_cs.Color.PURPLE;
            SetPosition(position);
            SetImage(Constants.ALIEN_IMAGE);
            SetWidth(72);
            SetHeight(49);
        }

        public override void Move(Point playerPos){
            //It doesn't move
        }
    }
}