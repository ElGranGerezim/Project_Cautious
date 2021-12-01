using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    public class Banner : Actor {
        public Banner(bool isVisible, string text){
            SetVisibility(isVisible);
            _subtitle = "Press Enter to Continue";
            SetImage(Constants.GAME_OVER_IMAGE);
            SetWidth(Constants.DEFAULT_BANNER_WIDTH);
            SetHeight(Constants.DEFAULT_BANNER_HEIGHT);
            Point center = new Point(Constants.MAX_X / 2 - (_width/2), Constants.MAX_Y / 2 - (_height / 2));
            SetPosition(center);
        }

        public void SetVisibility(bool isVisible){
            _isVisible = isVisible;
        }
    }
}