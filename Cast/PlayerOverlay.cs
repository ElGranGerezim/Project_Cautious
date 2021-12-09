using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    public class PlayerOverlay : Actor {
        Actor _body;

        public PlayerOverlay(Actor player){
            _body = player;
            SetImage(Constants.PLAYER_IMAGE);
            SetWidth(52);
            SetHeight(47);
            _isVisible = true;
        }

        public void HoldPosition(){
            int x = _body.GetX() - _width/2 + _body.GetWidth()/2;
            int y = _body.GetY() - _height/2 + _body.GetHeight()/2;
            SetPosition(new Point(x,y));
        }

        public void UpdateImage(){
            if (_body.canGetHit()){
                SetImage(Constants.PLAYER_IMAGE);
            } else{
                SetImage(Constants.PLAYER_IMAGE_HIT);
            }
        }
    }
}