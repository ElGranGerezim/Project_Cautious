using System;
using Project_Cautious.Cast.Basics;

namespace Project_Cautious.Cast{
    public class Banner : Actor {
        public Banner(bool isVisible, string text){
            SetVisibility(isVisible);
            SetText(text);
            SetWidth(Constants.DEFAULT_BANNER_WIDTH);
            SetHeight(Constants.DEFAULT_BANNER_HEIGHT);
            Point center = new Point(Constants.MAX_X / 2 - (_width/2), Constants.MAX_Y - (_height / 2)); 
        }

        public void SetVisibility(bool isVisible){
            _isVisible = isVisible;
        }
    }
}