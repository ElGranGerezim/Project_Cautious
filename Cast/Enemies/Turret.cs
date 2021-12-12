using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast.Enemies{
    public class Turret : Enemy{
        public Turret(Point position){
            _health = 5;
            _attack = patternName.Laser;
            _color = Raylib_cs.Color.RED;
            SetPosition(position);
            SetImage(Constants.TURRET_IMAGE);
            SetWidth(63);
            SetHeight(79);
        }

        public override void Move(Point playerPos)
        {
            if (playerPos.GetX() - 20 > GetX()){
                SetVelocity(new Point(1,0));
            } else if (playerPos.GetX() - 20 < GetX()){
                SetVelocity(new Point(-1,0));
            }
        }
    }
}